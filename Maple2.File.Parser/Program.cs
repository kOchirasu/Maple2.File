using System;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser {
    public static class Program {
        private const string EXPORTED_PATH = @"C:\Nexon\Library\maplestory2\appdata\Data\Resource\Exported.m2d";

        public static void Main() {
            Console.WriteLine("Hello MapleStory2!");
            FlatIndexExplorer();
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
                                Console.WriteLine($"  {subType}");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {string.Join(' ', input)}");
                        break;
                }
            }
        }
    }
}