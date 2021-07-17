using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser.MapXBlock {
    public class LibraryGenerator {
        private readonly FlatTypeIndex index;

        public LibraryGenerator(FlatTypeIndex index) {
            this.index = index;
        }

        public void Run() {
            const string root = "flat/library";
            IEnumerable<string> directories = index.Hierarchy.ListDirectories(root);
            foreach (string directory in directories) {
                string path = $"Library/{directory}";
                Directory.CreateDirectory(path);
                
                IEnumerable<FlatType> types = index.Hierarchy.List($"{root}/{directory}");
                foreach (FlatType type in types) {
                    /*string filePath;
                    string code;
                    if (Index.GetSubTypes(type.Name.ToLower()).Count == 0) {
                        filePath = Path.Combine(path, $"{type.Name}.cs");
                        code = GenerateClass(directory, type);
                    } else {
                        filePath = Path.Combine(path, $"I{type.Name}.cs");
                        code = GenerateInterface(directory, type);
                    }*/

                    // Generating all interfaces for now
                    string filePath = Path.Combine(path, $"I{type.Name}.cs");
                    string code = GenerateInterface(directory, type);
                    
                    if (System.IO.File.Exists(filePath)) {
                        throw new InvalidOperationException("Attempting to overwrite file: " + filePath);
                    }
                    
                    System.IO.File.WriteAllText(filePath, code);
                    Console.WriteLine("Created file at: " + filePath);
                }
            }
        }

        public string GenerateInterface(string @namespace, FlatType type) {
            var builder = new StringBuilder();

            builder.AppendLine($"namespace Maple2.File.Flat.Library.{@namespace} {{");
            List<string> mixinTypes = type.Mixin.Select(mixin => mixin.Name).ToList();
            foreach (string mixin in mixinTypes.ToList()) {
                foreach (FlatType subtype in index.GetSubTypes(mixin.ToLower())) {
                    mixinTypes.Remove(subtype.Name);
                }
            }
            List<string> mixinInterfaces = mixinTypes.Select(mixin => $"I{mixin}").ToList();
            if (mixinInterfaces.Count > 0) {
                builder.AppendLine($"public interface I{type.Name} : {string.Join(",", mixinInterfaces)} {{");
            } else {
                builder.AppendLine($"public interface I{type.Name} {{");
            }

            var inheritedProperties = new HashSet<string>();
            foreach (string mixinType in mixinTypes) {
                foreach (FlatProperty property in index.GetType(mixinType).GetAllProperties()) {
                    inheritedProperties.Add(property.Name);
                }
            }
            foreach (FlatProperty property in type.GetProperties()) {
                // Inherited properties don't need to be declared on interface
                if (inheritedProperties.Contains(property.Name)) {
                    continue;
                }
                string typeStr = NormalizeType(property.Value.GetType().ToString());
                builder.AppendLine($"{typeStr} {property.Name} {{ get; set; }}");
            }

            builder.AppendLine("}"); // class
            builder.AppendLine("}"); // namespace
            
            return builder.ToString();
        }

        public string GenerateClass(string @namespace, FlatType type) {
            var builder = new StringBuilder();

            builder.AppendLine($"namespace Maple2.File.Flat.Library.{@namespace} {{");
            List<string> mixinTypes = type.Mixin.Select(mixin => mixin.Name).ToList();
            foreach (string mixin in mixinTypes.ToList()) {
                foreach (FlatType subtype in index.GetSubTypes(mixin.ToLower())) {
                    mixinTypes.Remove(subtype.Name);
                }
            }
            List<string> mixinInterfaces = mixinTypes.Select(mixin => $"I{mixin}").ToList();
            if (mixinInterfaces.Count > 0) {
                builder.AppendLine($"public class {type.Name} : {string.Join(",", mixinInterfaces)} {{");
            } else {
                builder.AppendLine($"public class {type.Name} {{");
            }

            foreach (FlatProperty property in type.GetProperties()) {
                string typeStr = NormalizeType(property.Value.GetType().ToString());
                string typeValue = NormalizeTypeValue(property);
                builder.AppendLine($"public {typeStr} {property.Name} {{ get; set; }} = {typeValue};");
            }
            foreach (FlatProperty property in type.GetInheritedProperties()) {
                string typeStr = NormalizeType(property.Value.GetType().ToString());
                string typeValue = NormalizeTypeValue(property);
                builder.AppendLine($"{typeStr} {property.Name} {{ get; set; }} = {typeValue};");
            }

            builder.AppendLine("}"); // class
            builder.AppendLine("}"); // namespace
            
            return builder.ToString();
        }

        private string NormalizeType(string type) {
            return Regex.Replace(type, "Dictionary`2\\[(.+)\\]", "IDictionary<$1>");
        }

        private string NormalizeTypeValue(FlatProperty property) {
            string value = property.Value.ToString();
            if (property.Value is float) {
                value = Regex.Replace(value, "(\\d+\\.\\d+)", "$1f");
            }
            if (property.Value is Vector3) {
                value = Regex.Replace(value, "<(-?\\d+\\.?\\d*), (-?\\d+\\.?\\d*), (-?\\d+\\.?\\d*)>", "new Vector3($1, $2, $3)");
                value = Regex.Replace(value, "(\\d+\\.\\d+)", "$1f");
            }
            if (property.Value is Vector2) {
                value = Regex.Replace(value, "<(-?\\d+\\.?\\d*), (-?\\d+\\.?\\d*)>", "new Vector2($1, $2)");
                value = Regex.Replace(value, "(\\d+\\.\\d+)", "$1f");
            }
            if (property.Value is Color) {
                value = Regex.Replace(value, "Color \\[A=(\\d+), R=(\\d+), G=(\\d+), B=(\\d+)\\]", "Color.FromArgb($1, $2, $3, $4)");
            }
            if (property.Value is string) {
                value = $"\"{value}\"";
            }
            value = Regex.Replace(value, "System\\.Collections\\.Generic\\.Dictionary`2\\[(.+)\\]", "new Dictionary<$1>()");
            if (property.Value is bool) {
                value = value.ToLower();
            }
            return value;
        }
    }
}
