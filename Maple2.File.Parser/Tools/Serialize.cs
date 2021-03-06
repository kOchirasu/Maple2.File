using System.Numerics;

namespace Maple2.File.Parser.Tools {
    internal static class Serialize {
        public static string StringCsv(string[] data, char delimiter = ',') {
            return string.Join(delimiter, data);
        }

        public static string IntCsv(int[] data, char delimiter = ',') {
            return string.Join(delimiter, data);
        }

        public static string LongCsv(long[] data, char delimiter = ',') {
            return string.Join(delimiter, data);
        }

        public static string FloatCsv(float[] data, char delimiter = ',') {
            return string.Join(delimiter, data);
        }

        public static string Vector3(Vector3 data) {
            return $"{data.X},{data.Y},{data.Z}";
        }
    }
}