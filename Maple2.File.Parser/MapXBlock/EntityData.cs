using System;
using Maple2.File.Flat;

namespace Maple2.File.Parser.MapXBlock {
    public class EntityData {
        public readonly Type Type;
        private readonly Lazy<IMapEntity> value;

        public EntityData(Type type, Lazy<IMapEntity> value) {
            Type = type;
            this.value = value;
        }

        public T GetValue<T>() where T : IMapEntity {
            return (T) value.Value;
        }
    }
}
