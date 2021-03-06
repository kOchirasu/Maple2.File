using System;
using System.Linq;
using System.Numerics;

namespace Maple2.File.Parser.Tools {
    internal static class Deserialize {
        public static string[] StringCsv(string value) {
            return value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToArray();
        }

        public static int[] IntCsv(string value) {
            return value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        public static long[] LongCsv(string value) {
            return value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
        }

        public static float[] FloatCsv(string value) {
            return value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(float.Parse)
                .ToArray();
        }

        public static Vector3 Vector3(string value) {
            string[] split = value.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            float x = split.Length > 0 ? float.Parse(split[0]) : 0;
            float y = split.Length > 1 ? float.Parse(split[1]) : 0;
            float z = split.Length > 2 ? float.Parse(split[2]) : 0;

            return new Vector3(x, y, z);
        }
    }
}