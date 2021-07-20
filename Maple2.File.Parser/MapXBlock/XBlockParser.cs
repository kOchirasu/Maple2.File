using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Maple2.File.Flat;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser.MapXBlock {
    public class XBlockParser {
        private readonly M2dReader reader;
        private readonly XmlSerializer serializer;
        private readonly XBlockClassLookup lookup;
        private readonly FlatTypeIndex index;
        private readonly HashSet<Type> keepEntities;

        public XBlockParser(M2dReader reader, FlatTypeIndex index = null) {
            this.reader = reader;
            this.index = index ?? new FlatTypeIndex(reader);

            serializer = new XmlSerializer(typeof(GameXBlock));
            lookup = new XBlockClassLookup(index);
            keepEntities = new HashSet<Type>();
        }

        public bool Keep(Type type) {
            if (!typeof(IMapEntity).IsAssignableFrom(type)) {
                return false;
            }

            keepEntities.Add(type);
            return true;
        }

        public void Parse(Action<string, IEnumerable<IMapEntity>> callback) {
            foreach (PackFileEntry file in reader.Files) {
                if (!file.Name.StartsWith("xblock/")) continue;

                string xblock = Path.GetFileNameWithoutExtension(file.Name);
                callback(xblock, ParseEntities(file));
            }
        }

        public void ParseMap(string xblock, Action<IEnumerable<IMapEntity>> callback) {
            PackFileEntry file = reader.Files
                .FirstOrDefault(file => file.Name.Equals($"xblock/{xblock}.xblock"));
            if (file == default) {
                return;
            }

            callback(ParseEntities(file));
        }

        private IEnumerable<IMapEntity> ParseEntities(PackFileEntry file) {
            if (serializer.Deserialize(reader.GetXmlReader(file)) is GameXBlock block) {
                if (keepEntities.Count == 0) {
                    return block.entitySet.entity.Select(CreateInstance);
                }

                return block.entitySet.entity
                    .Where(entity => {
                        Type mixinType = lookup.GetMixinType(entity.modelName);
                        return keepEntities.Any(keep => keep.IsAssignableFrom(mixinType));
                    })
                    .Select(CreateInstance);
            }

            return Array.Empty<IMapEntity>();
        }

        private IMapEntity CreateInstance(Entity entity) {
            Type entityType = lookup.GetClass(entity.modelName);
            var mapEntity = (IMapEntity) Activator.CreateInstance(entityType);
            if (mapEntity == null) {
                throw new InvalidOperationException($"Unable to create instance of: {entity.modelName}");
            }

            var setPropertyValue = new List<(string, object)>();
            foreach (var property in entity.property) {
                // Not setting any values
                if (property.set.Count == 0) {
                    continue;
                }

                FlatType modelType = index.GetType(entity.modelName);
                FlatProperty modelProperty = modelType.GetProperty(property.name);

                object value;
                if (modelProperty.Type.StartsWith("Assoc")) {
                    value = FlatProperty.ParseAssocType(modelProperty.Type,
                        property.set.Select(set => (set.index, set.value)));
                } else {
                    value = FlatProperty.ParseType(modelProperty.Type, property.set[0].value);
                }

                setPropertyValue.Add((property.name, value));
            }

            setPropertyValue.Add(("EntityId", entity.id));
            setPropertyValue.Add(("EntityName", entity.name));

            foreach ((string name, object value) in setPropertyValue) {
                MethodInfo setter = entityType.GetMethod($"set_{name}");
                if (setter == null) {
                    throw new InvalidOperationException($"No function set_{name} on {entity.modelName}");
                }

                setter.Invoke(mapEntity, new[] {value});
            }

            return mapEntity;
        }
    }
}
