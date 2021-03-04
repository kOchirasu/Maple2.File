using System.Numerics;

namespace Maple2.File.Parser.Xml {
    internal static class Serialize {
        public static string StringCsv(string[] data) {
            return string.Join(',', data);
        }

        public static string IntCsv(int[] data) {
            return string.Join(',', data);
        }

        public static string LongCsv(long[] data) {
            return string.Join(',', data);
        }

        public static string FloatCsv(float[] data) {
            return string.Join(',', data);
        }

        public static string Vector3(Vector3 data) {
            return $"{data.X},{data.Y},{data.Z}";
        }
    }
}