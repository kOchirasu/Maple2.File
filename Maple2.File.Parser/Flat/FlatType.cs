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
            return Properties.Values;
        }

        public IEnumerable<FlatProperty> GetInheritedProperties() {
            HashSet<string> added = new HashSet<string>(Properties.Keys);
            List<FlatProperty> props = new List<FlatProperty>();
            for (int i = Mixin.Count - 1; i >= 0; i--) {
                foreach (FlatProperty prop in Mixin[i].GetAllProperties()) {
                    if (added.Contains(prop.Name)) {
                        continue;
                    }
                    added.Add(prop.Name);
                    props.Add(prop);
                }
            }

            return props;
        }

        public IEnumerable<FlatProperty> GetAllProperties() {
            Dictionary<string, FlatProperty> props = new Dictionary<string, FlatProperty>(Properties);
            for (int i = Mixin.Count - 1; i >= 0; i--) {
                foreach (FlatProperty prop in Mixin[i].GetAllProperties()) {
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