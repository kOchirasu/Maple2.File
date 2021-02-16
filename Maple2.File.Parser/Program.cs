using System;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser {
    public class Program {
        private const string EXPORTED_PATH = @"C:\Nexon\Library\maplestory2\appdata\Data\Resource\Exported.m2d";

        public static void Main() {
            Console.WriteLine("Hello MapleStory2!");
            FlatIndexExplorer();
        }

        private static void FlatIndexExplorer() {
            var index = new FlatTypeIndex(EXPORTED_PATH);

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

                            Console.WriteLine($"Type: {type}");
                            foreach (FlatProperty prop in type.GetProperties()) {
                                Console.WriteLine($"- {prop}");
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

                            Console.WriteLine($"Type: {type}");
                            foreach (FlatType subType in index.GetSubTypes(name)) {
                                Console.WriteLine($"- {subType}");
                            }
                        }
                        break;
                }
            }
        }
    }
}