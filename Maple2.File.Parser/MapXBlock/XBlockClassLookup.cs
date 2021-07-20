using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Maple2.File.Parser.Flat;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.MapXBlock {
    public class XBlockClassLookup {
        private readonly Dictionary<string, Type> cache;
        private readonly FlatTypeIndex index;
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
        
        public XBlockClassLookup(FlatTypeIndex index) {
            cache = new Dictionary<string, Type>();
            this.index = index;
            
            // Create a dynamic assembly and module.
            var assemblyName = new AssemblyName("Maple2.File.Flat.Runtime");
            if (string.IsNullOrEmpty(assemblyName.Name)) {
                throw new ArgumentException("Maple2.File.Flat.Runtime assembly not defined.");
            }
            moduleBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect)
                .DefineDynamicModule(assemblyName.Name);
        }

        public Type GetMixinType(string modelName) {
            FlatType entityType = index.GetType(modelName);
            // First try to directly lookup type as a library type
            Type mixinType = GetType($"I{modelName}");
            if (mixinType != null) {
                return mixinType;
            }
            
            List<FlatType> requiredMixins = entityType.RequiredMixin().ToList();
            if (requiredMixins.Count != 1) {
                throw new InvalidOperationException($"Cannot find single mixin for: {entityType}");
            }

            FlatType requiredMixin = requiredMixins.First();
            mixinType = GetType($"I{requiredMixin.Name}");
            if (mixinType == null) {
                throw new InvalidOperationException($"Mixin type: I{requiredMixin.Name} does not exist.");
            }
            
            return mixinType;
        }
        
        public Type GetClass(string modelName) {
            if (cache.TryGetValue(modelName, out Type classType)) {
                return classType;
            }
            
            FlatType entityType = index.GetType(modelName);
            Type mixinType = GetMixinType(modelName);

            TypeBuilder classBuilder = moduleBuilder.DefineType(
                modelName, 
                TypeAttributes.Class | TypeAttributes.Public, 
                typeof(object), 
                new[] { mixinType }
            );

            List<(FlatProperty, FieldInfo)> backingFields = new List<(FlatProperty, FieldInfo)>();
            
            // Override ModelName to this model's name.
            /*{
                (MethodInfo methodInfo, MethodBuilder methodBuilder) = OverrideMethod(classBuilder, mixinType, "get_ModelName");
                ILGenerator? ilGenerator = methodBuilder.GetILGenerator();
                if (ilGenerator == null) {
                    throw new InvalidOperationException($"{mixinType.Name} could not create ILGenerator.");
                }
                ilGenerator.EmitValue(modelName);
                ilGenerator.Emit(OpCodes.Ret);
                classBuilder.DefineMethodOverride(methodBuilder, methodInfo);
            }*/
            {
                FlatProperty property = new FlatProperty {
                    Name = "ModelName", 
                    Type = "String",
                    Value = modelName,
                };
                FieldInfo backing = CreateBacking(classBuilder, property);
                backingFields.Add((property, backing));
                OverrideGetter(classBuilder, backing, mixinType, property);
                CreateSetter(classBuilder, backing, property);
            }
            
            // Define class with property values
            foreach (FlatProperty property in entityType.GetProperties()) {
                /*if (property.Value is IDictionary) {
                    continue;
                }*/
                
                /*string methodName = $"get_{property.Name}";
                (MethodInfo methodInfo, MethodBuilder methodBuilder) = OverrideMethod(classBuilder, mixinType, methodName);
                ILGenerator? ilGenerator = methodBuilder.GetILGenerator();
                if (ilGenerator == null) {
                    throw new InvalidOperationException($"{mixinType.Name} could not create ILGenerator.");
                }

                ilGenerator.EmitValue(property.Value);
                ilGenerator.Emit(OpCodes.Ret);
                classBuilder.DefineMethodOverride(methodBuilder, methodInfo);*/

                FieldInfo backing = CreateBacking(classBuilder, property);
                backingFields.Add((property, backing));
                OverrideGetter(classBuilder, backing, mixinType, property);
                CreateSetter(classBuilder, backing, property);
            }
            
            CreateConstructor(classBuilder, backingFields);

            Type createdType = classBuilder.CreateType();
            if (createdType == null) {
                throw new InvalidOperationException($"Failed to generate class for {modelName}.");
            }
            cache.Add(modelName, createdType);
            return createdType;
        }

        private (MethodInfo, MethodBuilder) OverrideMethod(TypeBuilder classBuilder, Type mixinType, string methodName) {
            MethodInfo methodInfo = GetMethod(mixinType, methodName);
            if (methodInfo == null) {
                throw new InvalidOperationException($"{mixinType.Name} does not have method {methodName}.");
            }
                
            MethodBuilder methodBuilder = classBuilder.DefineMethod(
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

        private void CreateConstructor(TypeBuilder classBuilder, IEnumerable<(FlatProperty, FieldInfo)> fields) {
            ConstructorBuilder ctorBuilder = classBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            ILGenerator ilGenerator = ctorBuilder.GetILGenerator();
            if (ilGenerator == null) {
                throw new InvalidOperationException($"Could not create ILGenerator for constructor.");
            }
            
            foreach ((FlatProperty property, FieldInfo field) in fields) {
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.EmitValue(property.Value);
                ilGenerator.Emit(OpCodes.Stfld, field);
            }
            
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Call, typeof(Object).GetConstructor(Type.EmptyTypes));
            ilGenerator.Emit(OpCodes.Ret);
        }

        private FieldInfo CreateBacking(TypeBuilder classBuilder, FlatProperty property) {
            string fieldName = $"_{property.Name}";
            FieldBuilder fieldBuilder = classBuilder.DefineField(
                fieldName,
                property.Value.GetType(),
                FieldAttributes.Private
            );
            if (fieldBuilder == null) {
                throw new InvalidOperationException($"{property.Name} could not create FieldBuilder.");
            }

            return fieldBuilder;
        }
        
        private void OverrideGetter(TypeBuilder classBuilder, FieldInfo backing, Type mixinType, FlatProperty property) {
            string methodName = $"get_{property.Name}";
            MethodInfo methodInfo = GetMethod(mixinType, methodName);
            if (methodInfo == null) {
                throw new InvalidOperationException($"{mixinType.Name} does not have method {methodName}.");
            }
                
            MethodBuilder methodBuilder = classBuilder.DefineMethod(
                methodName, 
                MethodAttributes.Public | MethodAttributes.Virtual, 
                methodInfo.ReturnType, 
                Type.EmptyTypes
            );
            if (methodBuilder == null) {
                throw new InvalidOperationException($"{mixinType.Name} could not create MethodBuilder.");
            }
            
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();
            if (ilGenerator == null) {
                throw new InvalidOperationException($"{mixinType.Name} could not create ILGenerator.");
            }
            
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, backing);
            ilGenerator.Emit(OpCodes.Ret);
            
            classBuilder.DefineMethodOverride(methodBuilder, methodInfo);
        }

        private void CreateSetter(TypeBuilder classBuilder, FieldInfo backing, FlatProperty property) {
            string methodName = $"set_{property.Name}";
            MethodBuilder methodBuilder = classBuilder.DefineMethod(
                methodName, 
                MethodAttributes.Public, 
                typeof(void), 
                new [] {property.Value.GetType()}
            );
            if (methodBuilder == null) {
                throw new InvalidOperationException($"{property.Name} could not create MethodBuilder.");
            }
            
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();
            if (ilGenerator == null) {
                throw new InvalidOperationException($"{property.Name} could not create ILGenerator.");
            }
            
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Stfld, backing);
            ilGenerator.Emit(OpCodes.Ret);
        }

        // GetType that searches in Maple2.File.Flat assembly
        private static Type GetType(string name) {
            const string assemblyName = "Maple2.File.Flat";
            foreach (string @namespace in namespaces) {
                Type type;
                if ((type = Type.GetType($"{assemblyName}.{@namespace}.{name}, {assemblyName}")) != null) {
                    return type;
                }
            }

            return null;
        }

        // GetMethod that also searches in implemented interfaces.
        private static MethodInfo GetMethod(Type type, string name, BindingFlags flags = BindingFlags.Default) {
            MethodInfo methodInfo = type.GetMethod(name);
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
