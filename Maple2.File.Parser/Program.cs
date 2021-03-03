using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.IO.Tok;
using Maple2.File.IO.Tok.XmlTypes;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser {
    public static class Program {
        private const string EXPORTED_PATH = @"C:\Nexon\Library\maplestory2\appdata\Data\Resource\Exported.m2d";
        private const string PRECOMPUTED_TERRAIN_PATH = @"C:\Nexon\Library\maplestory2\appdata\Data\Resource\PrecomputedTerrain.m2d";

        public static void Main() {
            Console.WriteLine("Hello MapleStory2!");
            FlatIndexExplorer();
            //DumpPrecomputedTerrainXml();
        }

        private static void FlatIndexExplorer() {
            var index = new FlatTypeIndex(EXPORTED_PATH);
            Console.WriteLine("Index is ready!");

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
                            FlatType type = index.GetType(name);
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
                            FlatType type = index.GetType(name);
                            if (type == null) {
                                Console.WriteLine($"Invalid type: {name}");
                                continue;
                            }

                            Console.WriteLine(type);
                            foreach (FlatType subType in index.GetSubTypes(name)) {
                                Console.WriteLine($"{subType.Name,30} : {string.Join(',', subType.Mixin.Select(sub => sub.Name))}");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {string.Join(' ', input)}");
                        break;
                }
            }
        }

        private static void DumpPrecomputedTerrainXml() {
            var reader = new M2dReader(PRECOMPUTED_TERRAIN_PATH);
            Directory.CreateDirectory("PrecomputedTerrain");
            foreach (PackFileEntry file in reader.Files) {
                if (!file.Name.EndsWith(".tok")) continue;

                byte[] bytes = reader.GetBytes(file);
                var tokReader = new TokReader(bytes);
                Mesh mesh = tokReader.Parse();

                var serializer = new XmlSerializer(typeof(Mesh));
                var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                var settings = new XmlWriterSettings {Indent = true, OmitXmlDeclaration = true};

                using var strWriter = new StringWriter();
                using var xmlWriter = XmlWriter.Create(strWriter, settings);
                serializer.Serialize(xmlWriter, mesh, emptyNamespaces);


                string xml = strWriter.ToString();
                string fileName = Path.GetFileNameWithoutExtension(file.Name);
                System.IO.File.WriteAllText($"PrecomputedTerrain\\{fileName}.xml", xml);
                Console.WriteLine($"Completed: {file.Name}");
            }
        }
    }
}