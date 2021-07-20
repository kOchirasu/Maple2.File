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
        private readonly HashSet<Type> includeEntities;

        public XBlockParser(M2dReader reader, FlatTypeIndex index) {
            this.reader = reader;
            this.index = index ?? new FlatTypeIndex(reader);

            serializer = new XmlSerializer(typeof(GameXBlock));
            lookup = new XBlockClassLookup(this.index);
            includeEntities = new HashSet<Type>();
        }

        public bool Include(Type type) {
            if (!typeof(IMapEntity).IsAssignableFrom(type)) {
                return false;
            }

            includeEntities.Add(type);
            return true;
        }

        public void Parse(Action<string, IEnumerable<IMapEntity>> callback) {
            IEnumerable<(string, IEnumerable<IMapEntity>)> results = reader.Files
                .Where(file => file.Name.StartsWith("xblock/"))
                .Select(file => {
                    string xblock = Path.GetFileNameWithoutExtension(file.Name);
                    return (xblock, ParseEntities(file));
                });
            
            foreach ((string xblock, IEnumerable<IMapEntity> entities) in results) {
                callback(xblock, entities);
            }
        }

        public void ParseParallel(Action<string, IEnumerable<IMapEntity>> callback) {
            IEnumerable<(string, IEnumerable<IMapEntity>)> results = reader.Files
                .Where(file => file.Name.StartsWith("xblock/"))
                .AsParallel()
                .Select(file => {
                    string xblock = Path.GetFileNameWithoutExtension(file.Name);
                    return (xblock, ParseEntities(file));
                })
                .AsSequential();
            
            foreach ((string xblock, IEnumerable<IMapEntity> entities) in results) {
                callback(xblock, entities);
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
                var unknownModels = new HashSet<string>();
                return block.entitySet.entity
                    .Where(entity => {
                        try {
                            Type mixinType = lookup.GetMixinType(entity.modelName);
                            return includeEntities.Count == 0 || includeEntities.Any(keep => keep.IsAssignableFrom(mixinType));
                        } catch {
                            return false;
                        }
                    })
                    .Select(entity => {
                        try {
                            return CreateInstance(entity);
                        } catch (UnknownModelTypeException ex) {
                            // Reduce noise from this exception to once per file
                            if (unknownModels.Add(entity.modelName)) {
                                Console.WriteLine(ex);
                            }
                            return null;
                        }
                    })
                    .Where(entity => entity != null);
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
                if (modelProperty == null) {
                    Console.WriteLine($"Ignored unknown property {property.name} on {modelType.Name}");
                    continue;
                }

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
                    throw new UnknownPropertyException(entityType, $"set_{name}");
                }

                setter.Invoke(mapEntity, new[] {value});
            }

            return mapEntity;
        }
    }
}
