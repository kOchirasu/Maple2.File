using System.Collections.Generic;
using System.Linq;

namespace Maple2.File.Parser.Flat {
    public class FlatType {
        public readonly string Name;
        public readonly List<FlatType> Mixin;
        public readonly Dictionary<string, FlatProperty> Properties;

        public FlatType(string name) {
            Name = name;
            Mixin = new List<FlatType>();
            Properties = new Dictionary<string, FlatProperty>();
        }

        public FlatProperty GetProperty(string name) {
            if (Properties.ContainsKey(name)) {
                return Properties[name];
            }

            for (int i = Mixin.Count - 1; i >= 0; i--) {
                FlatProperty prop = Mixin[i].GetProperty(name);
                if (prop != null) {
                    return prop;
                }
            }

            return null;
        }

        public IEnumerable<FlatProperty> GetProperties() {
            Dictionary<string, FlatProperty> props = new(Properties);
            for (int i = Mixin.Count - 1; i >= 0; i--) {
                foreach (FlatProperty prop in Mixin[i].GetProperties()) {
                    props.TryAdd(prop.Name, prop);
                }
            }

            return props.Values;
        }

        public override string ToString() {
            return $"{Name} : {string.Join(',', Mixin.Select(type => type.Name))}";
        }
    }
}