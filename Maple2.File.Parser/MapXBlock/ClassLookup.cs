using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Maple2.File.Flat;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser.MapXBlock {
    public abstract class ClassLookup {
        private static readonly Dictionary<string, Type> typeIndex = new Dictionary<string, Type>();
        private static readonly ConcurrentDictionary<string, MethodInfo> MethodCache =
            new ConcurrentDictionary<string, MethodInfo>();

        private readonly Dictionary<string, Type> mixinTypeCache = new Dictionary<string, Type>();
        protected readonly FlatTypeIndex index;

        static ClassLookup() {
            foreach (Type type in Assembly.GetAssembly(typeof(IMapEntity)).GetTypes()) {
                typeIndex[type.Name] = type;
            }
        }

        protected ClassLookup(FlatTypeIndex index) {
            this.index = index;
        }
        
        public Type GetMixinType(string modelName) {
            if (mixinTypeCache.TryGetValue(modelName, out Type mixinType)) {
                return mixinType;
            }
            
            FlatType entityType = index.GetType(modelName);
            if (entityType == null) {
                throw new UnknownModelTypeException(modelName);
            }
            // First try to directly lookup type as a library type
            mixinType = GetType($"I{modelName}");
            if (mixinType != null) {
                mixinTypeCache[modelName] = mixinType;
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

            mixinTypeCache[modelName] = mixinType;
            return mixinType;
        }
        
        public abstract Type GetClass(string modelName);
        
        public static Type GetType(string name) => typeIndex.GetValueOrDefault(name);

        // GetMethod that also searches in implemented interfaces.
        protected static MethodInfo GetMethod(Type type, string name) {
            string key = $"{type.Name}.{name}";
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
