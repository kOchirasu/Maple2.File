using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace Maple2.File.Parser.Flat {
    public class FlatProperty {
        public string Name { get; set; }
        public string Id { get; set; }

        public string Type { get; set; }
        public object Value { get; set; }

        public static object ParseType(string type, string value) {
            switch (type) {
                case "Boolean":
                    return bool.Parse(value);
                case "UInt16":
                    return ushort.Parse(value);
                case "UInt32":
                    return uint.Parse(value);
                case "SInt32":
                    return int.Parse(value);
                case "Float32":
                    return float.Parse(value);
                case "Float64":
                    return double.Parse(value);
                case "Point3":
                    float[] point3 = FloatList(value);
                    return new Vector3(point3[0], point3[1], point3[2]);
                case "Point2":
                    float[] point2 = FloatList(value);
                    return new Vector2(point2[0], point2[1]);
                case "Color":
                    int[] color = FloatList(value).Select(argb => (int) (255 * argb)).ToArray();
                    return Color.FromArgb(color[0], color[1], color[2]);
                case "ColorA":
                    int[] colorA = FloatList(value).Select(argb => (int) (255 * argb)).ToArray();
                    return Color.FromArgb(colorA[3], colorA[0], colorA[1], colorA[2]);
                case "String":
                case "EntityRef": // GUID
                case "AssetID": // urn:llid:GUID
                    //case "AttachedNifAsset": // Used only for Assoc
                    return value;
                default:
                    throw new ArgumentException($"Invalid Type: {type}");
            }
        }

        public static object ParseAssocType(string type, IEnumerable<(string Index, string Value)> values) {
            switch (type) {
                case "AssocString":
                case "AssocEntityRef":
                case "AssocAttachedNifAsset":
                    Dictionary<string, string> assocString = new Dictionary<string, string>();
                    foreach ((string index, string value) in values) {
                        assocString[index] = (string) ParseType("String", value);
                    }

                    return assocString;
                case "AssocPoint3":
                    Dictionary<string, Vector3> assocPoint3 = new Dictionary<string, Vector3>();
                    foreach ((string index, string value) in values) {
                        assocPoint3[index] = (Vector3) ParseType("Point3", value);
                    }

                    return assocPoint3;
                case "AssocUInt32":
                    Dictionary<string, uint> assocUInt32 = new Dictionary<string, uint>();
                    foreach ((string index, string value) in values) {
                        assocUInt32[index] = (uint) ParseType("UInt32", value);
                    }

                    return assocUInt32;
                case "AssocSInt32":
                    Dictionary<string, int> assocSInt32 = new Dictionary<string, int>();
                    foreach ((string index, string value) in values) {
                        assocSInt32[index] = (int) ParseType("SInt32", value);
                    }

                    return assocSInt32;
                default:
                    throw new ArgumentException($"Invalid AssocType: {type}");
            }
        }

        private static float[] FloatList(string value) {
            string[] split = value.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            float[] result = new float[split.Length];
            for (int i = 0; i < split.Length; i++) {
                result[i] = float.Parse(split[i]);
            }

            return result;
        }

        public string ValueString() {
            if (!(Value is IDictionary dict)) {
                return $"{Value.GetType().Name}{{{Value}}}";
            }

            IEnumerable<string> entries = CastDict(dict)
                .Select(entry => $"{entry.Key}: {entry.Value.GetType().Name}({entry.Value})");
            return $"Dictionary{{{string.Join(',', entries)}}}";
        }

        private IEnumerable<DictionaryEntry> CastDict(IDictionary dictionary) {
            foreach (DictionaryEntry entry in dictionary) {
                yield return entry;
            }
        }

        public override string ToString() {
            return $"{Type}\t{Name}: {ValueString()})";
        }
    }
}