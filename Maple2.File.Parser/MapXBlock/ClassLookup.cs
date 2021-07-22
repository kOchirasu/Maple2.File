using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser.MapXBlock {
    public abstract class ClassLookup {
        protected readonly FlatTypeIndex index;
        
        public ClassLookup(FlatTypeIndex index) {
            this.index = index;
        }
        
        public Type GetMixinType(string modelName) {
            FlatType entityType = index.GetType(modelName);
            if (entityType == null) {
                throw new UnknownModelTypeException(modelName);
            }
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
                throw new UnknownModelTypeException($"I{requiredMixin.Name}");
            }

            return mixinType;
        }
        
        public abstract Type GetClass(string modelName);
        
        private static readonly string[] Namespaces = {
            "beastmodellibrary",
            "gimodellibrary",
            "maplestory2library",
            "physxmodellibrary",
            "standardmodellibrary",
            "tool",
            "triggerslibrary",
            "presets",
        };
        
        // GetType that searches in Maple2.File.Flat assembly
        private static readonly Dictionary<string, Type> TypeCache = new Dictionary<string, Type>();
        public static Type GetType(string name) {
            if (TypeCache.TryGetValue(name, out Type type)) {
                return type;
            }
            
            const string assemblyName = "Maple2.File.Flat";
            foreach (string @namespace in Namespaces) {
                if ((type = Type.GetType($"{assemblyName}.{@namespace}.{name}, {assemblyName}")) != null) {
                    TypeCache[name] = type;
                    return type;
                }
            }

            TypeCache[name] = null;
            return null;
        }

        // GetMethod that also searches in implemented interfaces.
        private static readonly Dictionary<string, MethodInfo> MethodCache = new Dictionary<string, MethodInfo>();
        public static MethodInfo GetMethod(Type type, string name) {
            string key = type.FullName + name;
            if (MethodCache.TryGetValue(key, out MethodInfo methodInfo)) {
                return methodInfo;
            }
            methodInfo = type.GetMethod(name);
            if (methodInfo != null) {
                MethodCache[key] = methodInfo;
                return methodInfo;
            }

            foreach (Type @interface in type.GetInterfaces()) {
                methodInfo = GetMethod(@interface, name);
                if (methodInfo != null) {
                    MethodCache[key] = methodInfo;
                    return methodInfo;
                }
            }

            MethodCache[key] = null;
            return null;
        }
        
        public static string NormalizeClass(string className) {
            className = className.Replace("(", "").Replace(")", "").Replace(" ", "");
            if (Regex.IsMatch(className, @"^\d")) {
                className = $"_{className}";
            }

            return className;
        }
    }
}
