using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;

namespace Maple2.File.Parser.Flat {
    public class FlatTypeIndex {
        private readonly string root; // flat, flat/library, flat/presets
        private readonly Dictionary<string, FlatTypeNode> typeNodes;

        public FlatTypeIndex(string exportedPath, string root = "flat") {
            this.root = root;
            typeNodes = ReadTypeNodes(exportedPath);

            foreach (FlatTypeNode typeNode in typeNodes.Values) {
                foreach (FlatType mixin in typeNode.Value.Mixin) {
                    typeNodes[mixin.Name.ToLower()].Children.Add(typeNode);
                }
            }
        }

        public IEnumerable<FlatType> GetAllTypes() {
            return typeNodes.Values.Select(node => node.Value);
        }

        public FlatType GetType(string name) {
            return typeNodes.GetValueOrDefault(name.ToLower(), null)?.Value;
        }

        public List<FlatType> GetSubTypes(string name) {
            if (!typeNodes.ContainsKey(name.ToLower())) {
                return new List<FlatType>();
            }

            return typeNodes[name.ToLower()].Children
                .Select(node => node.Value)
                .ToList();
        }

        // Builds Index
        private Dictionary<string, FlatTypeNode> ReadTypeNodes(string exportedPath) {
            var reader = new M2dReader(exportedPath);

            Dictionary<string, XmlNode> xmlNodes = new Dictionary<string, XmlNode>();
            Dictionary<string, FlatTypeNode> types = new Dictionary<string, FlatTypeNode>();
            foreach (PackFileEntry entry in reader.Files) {
                if (!entry.Name.StartsWith(root)) continue;

                XmlDocument xmlDocument = reader.GetXmlDocument(entry);
                XmlNode node = xmlDocument.SelectSingleNode("model");
                if (node == null) {
                    Console.WriteLine($"Missing model node for: {entry.Name}");
                    continue;
                }
                if (node.Attributes?["name"] == null) {
                    Console.WriteLine($"Missing name for: {entry.Name}");
                    continue;
                }

                string name = node.Attributes["name"].Value;
                xmlNodes[name] = node;
                types[name.ToLower()] = new FlatTypeNode(new FlatType(name));
                //Console.WriteLine($"Created type: {type.Name}");
            }

            // Populate Mixin and Property for Types.
            foreach ((string name, XmlNode node) in xmlNodes) {
                FlatType type = types[name.ToLower()].Value;
                XmlNodeList mixinNodes = node.SelectNodes("mixin");
                foreach (XmlNode mixinNode in mixinNodes) {
                    string mixinName = mixinNode.Attributes["name"].Value;
                    type.Mixin.Add(types[mixinName.ToLower()].Value);
                }

                XmlNodeList propNodes = node.SelectNodes("property");
                foreach (XmlNode propNode in propNodes) {
                    if (propNode?.Attributes == null) {
                        throw new ConstraintException("Null value found for property node");
                    }

                    FlatProperty property;

                    XmlNodeList setNodes = propNode.SelectNodes("set");
                    string propName = propNode.Attributes["name"].Value;
                    string propType = propNode.Attributes["type"].Value;
                    string propId = propNode.Attributes["id"].Value;

                    if (propType.StartsWith("Assoc")) {
                        List<(string, string)> values = new List<(string, string)>();
                        foreach (XmlNode setNode in setNodes) {
                            values.Add((setNode.Attributes["index"].Value, setNode.Attributes["value"].Value));
                        }

                        property = new FlatProperty {
                            Name = propName,
                            Type = propType,
                            Id = propId,
                            Value = FlatProperty.ParseAssocType(propType, values),
                        };
                    } else {
                        string value = setNodes[0].Attributes["value"].Value;
                        property = new FlatProperty {
                            Name = propName,
                            Type = propType,
                            Id = propId,
                            Value = FlatProperty.ParseType(propType, value),
                        };
                    }

                    type.Properties.Add(property.Name, property);
                }
            }

            return types;
        }

        private class FlatTypeNode {
            public readonly FlatType Value;
            public readonly List<FlatTypeNode> Children;

            public FlatTypeNode(FlatType value) {
                Value = value;
                Children = new List<FlatTypeNode>();
            }
        }
    }
}