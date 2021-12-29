using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Flat; 

public class FlatTypeIndex {
    public readonly HierarchyMap<FlatType> Hierarchy;

    private readonly string root; // flat, flat/library, flat/presets
    private readonly Dictionary<string, FlatTypeNode> typeNodes;

    public FlatTypeIndex(M2dReader reader, string root = "flat") {
        this.root = root;
        Hierarchy = new HierarchyMap<FlatType>();
        typeNodes = ReadTypeNodes(reader);

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
    private Dictionary<string, FlatTypeNode> ReadTypeNodes(M2dReader reader) {
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
            var type = new FlatType(name);
            Hierarchy.Add(entry.Name, type);
            types[name.ToLower()] = new FlatTypeNode(type);
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

                // Don't add this property if the same value is already inherited
                FlatProperty inheritedProperty = type.GetProperty(property.Name);
                if (inheritedProperty != null && inheritedProperty.ValueEquals(property.Value)) {
                    continue;
                }

                type.Properties.Add(property.Name, property);
            }
        }

        return types;
    }

    public void CliExplorer() {
        while (true) {
            string[] input = (Console.ReadLine() ?? string.Empty).Split(" ", 2);

            switch (input[0]) {
                case "quit":
                    return;
                case "type":
                case "prop":
                case "properties":
                    if (input.Length < 2) {
                        Console.WriteLine("Invalid input.");
                    } else {
                        string name = input[1];
                        FlatType type = GetType(name);
                        if (type == null) {
                            Console.WriteLine($"Invalid type: {name}");
                            continue;
                        }

                        Console.WriteLine(type);
                        foreach (FlatProperty prop in type.GetProperties()) {
                            Console.WriteLine($"{prop.Type,22}{prop.Name,30}: {prop.ValueString()}");
                        }

                        Console.WriteLine("----------------------Inherited------------------------");
                        foreach (FlatProperty prop in type.GetInheritedProperties()) {
                            Console.WriteLine($"{prop.Type,22}{prop.Name,30}: {prop.ValueString()}");
                        }
                    }
                    break;
                case "sub":
                case "children":
                    if (input.Length < 2) {
                        Console.WriteLine("Invalid input.");
                    } else {
                        string name = input[1];
                        FlatType type = GetType(name);
                        if (type == null) {
                            Console.WriteLine($"Invalid type: {name}");
                            continue;
                        }

                        Console.WriteLine(type);
                        foreach (FlatType subType in GetSubTypes(name)) {
                            Console.WriteLine($"{subType.Name,30} : {string.Join(',', subType.Mixin.Select(sub => sub.Name))}");
                        }
                    }
                    break;
                case "ls":
                    try {
                        bool recursive = input.Contains("-r");
                        string path = input.FirstOrDefault(arg => arg != "ls" && arg != "-r");
                        Console.WriteLine(string.Join(", ", Hierarchy.List(path, recursive).Select(type => type.Name)));
                    } catch (DirectoryNotFoundException e) {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "lsdir":
                    try {
                        string path = input.FirstOrDefault(arg => arg != "lsdir");
                        Console.WriteLine(string.Join(", ", Hierarchy.ListDirectories(path)));
                    } catch (DirectoryNotFoundException e) {
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:
                    Console.WriteLine($"Unknown command: {string.Join(' ', input)}");
                    break;
            }
        }
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