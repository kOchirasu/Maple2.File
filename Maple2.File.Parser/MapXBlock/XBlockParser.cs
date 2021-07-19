#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Serialization;
using Maple2.File.Flat;
using Maple2.File.Flat.maplestory2library;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Flat;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.MapXBlock {
    public class XBlockParser {
        private readonly FlatTypeIndex index;
        private readonly HashSet<Type> listeners;
        private readonly ModuleBuilder moduleBuilder;
        
        private static readonly string[] namespaces = {
            "beastmodellibrary", 
            "gimodellibrary", 
            "maplestory2library", 
            "physxmodellibrary",
            "standardmodellibrary",
            "tool",
            "triggerslibrary"
        };
        
        public XBlockParser(FlatTypeIndex index) {
            this.index = index;
            listeners = new HashSet<Type>();
            
            // Create a dynamic assembly and module.
            var assemblyName = new AssemblyName("Maple2.File.Flat.Runtime");
            if (string.IsNullOrEmpty(assemblyName.Name)) {
                throw new ArgumentException("Maple2.File.Flat.Runtime assembly not defined.");
            }
            moduleBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect)
                .DefineDynamicModule(assemblyName.Name);
        }

        public void Register<T>() where T : IMapEntity {
            listeners.Add(typeof(T));
        }

        public void Parse(Action<string, IEnumerable<IMapEntity>> callback) {
            var exportedReader = new M2dReader(Program.EXPORTED_PATH);
            XmlSerializer serializer = Program.MakeSerializer<GameXBlock>();
            foreach (PackFileEntry file in exportedReader.Files) {
                if (!file.Name.StartsWith("xblock/")) continue;
                
                string xblock = Path.GetFileNameWithoutExtension(file.Name);
                var block = (GameXBlock) serializer.Deserialize(exportedReader.GetXmlReader(file));
                if (block != null) {
                    callback(xblock, block.entitySet.entity.Select(entity => entity.modelName)
                        .Select(CreateInstance).Where(entity => entity != default));
                }
            }
        }

        public IMapEntity CreateInstance(string modelName) {
            FlatType entityType = index.GetType(modelName);
            List<FlatType> requiredMixins = entityType.RequiredMixin().ToList();
            if (requiredMixins.Count != 1) {
                return default; // Invalid mixin...
            }

            FlatType requiredMixin = requiredMixins.First();
            Type? mixinType = GetType($"I{requiredMixin.Name}");
            if (mixinType == null) {
                throw new InvalidOperationException($"Mixin type: I{requiredMixin.Name} does not exist.");
            }
            TypeBuilder classBuilder = moduleBuilder.DefineType(
                modelName, 
                TypeAttributes.Class | TypeAttributes.Public, 
                typeof(object), 
                new[] { mixinType }
            );
            classBuilder.DefineDefaultConstructor(MethodAttributes.Public);

            // Override ModelName to this model's name.
            {
                (MethodInfo methodInfo, MethodBuilder methodBuilder) = OverrideMethod(classBuilder, mixinType, "get_ModelName");
                ILGenerator? ilGenerator = methodBuilder.GetILGenerator();
                if (ilGenerator == null) {
                    throw new InvalidOperationException($"{mixinType.Name} could not create ILGenerator.");
                }
                ilGenerator.EmitValue(modelName);
                ilGenerator.Emit(OpCodes.Ret);
                classBuilder.DefineMethodOverride(methodBuilder, methodInfo);
            }
            
            // Define class with property values
            foreach (FlatProperty property in entityType.GetProperties()) {
                string methodName = $"get_{property.Name}";
                //Console.WriteLine(methodName + " = " + property.ValueString());
                (MethodInfo methodInfo, MethodBuilder methodBuilder) = OverrideMethod(classBuilder, mixinType, methodName);
                ILGenerator? ilGenerator = methodBuilder.GetILGenerator();
                if (ilGenerator == null) {
                    throw new InvalidOperationException($"{mixinType.Name} could not create ILGenerator.");
                }
                
                ilGenerator.EmitValue(property.Value);
                ilGenerator.Emit(OpCodes.Ret);
                classBuilder.DefineMethodOverride(methodBuilder, methodInfo);
            }

            Type? createdType = classBuilder.CreateType();
            return (IMapEntity)Activator.CreateInstance(createdType);
        }

        private (MethodInfo, MethodBuilder) OverrideMethod(TypeBuilder classBuilder, Type mixinType, string methodName) {
            MethodInfo? methodInfo = GetMethod(mixinType, methodName);
            if (methodInfo == null) {
                throw new InvalidOperationException($"{mixinType.Name} does not have method {methodName}.");
            }
                
            MethodBuilder? methodBuilder = classBuilder.DefineMethod(
                methodName, 
                MethodAttributes.Public | MethodAttributes.Virtual, 
                methodInfo.ReturnType, 
                Type.EmptyTypes
            );
            if (methodBuilder == null) {
                throw new InvalidOperationException($"{mixinType.Name} could not create MethodBuilder.");
            }
            return (methodInfo, methodBuilder);
        }
        
        // GetType that searches in Maple2.File.Flat assembly
        private static Type? GetType(string name) {
            const string assemblyName = "Maple2.File.Flat";
            foreach (string @namespace in namespaces) {
                Type? type;
                if ((type = Type.GetType($"{assemblyName}.{@namespace}.{name}, {assemblyName}")) != null) {
                    return type;
                }
            }

            return null;
        }

        // GetMethod that also searches in implemented interfaces.
        private static MethodInfo? GetMethod(Type type, string name, BindingFlags flags = BindingFlags.Default) {
            MethodInfo? methodInfo = type.GetMethod(name);
            if (methodInfo != null) {
                return methodInfo;
            }

            foreach (Type @interface in type.GetInterfaces()) {
                methodInfo = GetMethod(@interface, name, flags);
                if (methodInfo != null) {
                    return methodInfo;
                }
            }

            return null;
        }
    }
}
