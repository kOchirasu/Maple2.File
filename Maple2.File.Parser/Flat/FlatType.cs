using System;
using System.Collections.Generic;
using System.Linq;

namespace Maple2.File.Parser.Flat;

public class FlatType {
    public readonly string Name;
    public readonly uint Id;
    public readonly List<string> Trait;
    public readonly List<FlatType> Mixin;
    public readonly Dictionary<string, FlatProperty> Properties;
    public readonly Dictionary<string, FlatBehavior> Behaviors;

    public FlatType(string name, uint id) {
        Name = name;
        Id = id;
        Trait = new List<string>();
        Mixin = new List<FlatType>();
        Properties = new Dictionary<string, FlatProperty>();
        Behaviors = new Dictionary<string, FlatBehavior>();
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

    public IEnumerable<FlatProperty> GetNewProperties() {
        var props = new Dictionary<string, FlatProperty>(Properties);
        for (int i = Mixin.Count - 1; i >= 0; i--) {
            foreach (FlatProperty prop in Mixin[i].GetAllProperties()) {
                props.Remove(prop.Name);
            }
        }

        return props.Values;
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

    public IEnumerable<FlatBehavior> GetNewBehaviors() {
        var behaviors = new Dictionary<string, FlatBehavior>(Behaviors);
        for (int i = Mixin.Count - 1; i >= 0; i--) {
            foreach (FlatBehavior behavior in Mixin[i].GetAllBehaviors()) {
                behaviors.Remove(behavior.Name);
            }
        }

        return behaviors.Values;
    }

    public IEnumerable<FlatBehavior> GetAllBehaviors() {
        var behaviors = new Dictionary<string, FlatBehavior>(Behaviors);
        for (int i = Mixin.Count - 1; i >= 0; i--) {
            foreach (FlatBehavior behavior in Mixin[i].GetAllBehaviors()) {
                behaviors.TryAdd(behavior.Name, behavior);
            }
        }

        return behaviors.Values;
    }

    public bool IsRedundantMixin(FlatType type) {
        foreach (FlatType mixinType in Mixin) {
            if (mixinType.Equals(type)) {
                continue;
            }

            if (mixinType.Mixin.Contains(type)) {
                return true;
            }

            if (mixinType.IsRedundantMixin(type)) {
                return true;
            }
        }

        return false;
    }

    // Removes any mixins that are already satisfied by another.
    public IEnumerable<FlatType> RequiredMixin() {
        return Mixin.Where(mixin => !IsRedundantMixin(mixin));
    }

    // Generates a deterministic random Guid from Id.
    public Guid ToGuid() {
        byte[] rand = new byte[16];
        new Random(unchecked((int) Id)).NextBytes(rand);
        return new Guid(rand);
    }

    protected bool Equals(FlatType other) {
        if (Name != other.Name || Properties.Count != other.Properties.Count) {
            return false;
        }

        foreach ((string key, FlatProperty value) in Properties) {
            if (!other.Properties.TryGetValue(key, out FlatProperty otherValue)) {
                return false;
            }
            if (!value.Equals(otherValue)) {
                return false;
            }
        }

        return true;
    }

    public override bool Equals(object obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FlatType) obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Name, Properties);
    }

    public override string ToString() {
        return $"{Name} : {string.Join(',', Mixin.Select(type => type.Name))}";
    }
}
