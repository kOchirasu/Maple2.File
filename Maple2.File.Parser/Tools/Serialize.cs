using System.Drawing;
using System.Numerics;

namespace Maple2.File.Parser.Tools {
    internal static class Serialize {
        public static string StringCsv(string[] data, char delimiter = ',') {
            return data == null ? null : string.Join(delimiter, data);
        }

        public static string IntCsv(int[] data, char delimiter = ',') {
            return data == null ? null : string.Join(delimiter, data);
        }

        public static string LongCsv(long[] data, char delimiter = ',') {
            return data == null ? null : string.Join(delimiter, data);
        }

        public static string FloatCsv(float[] data, char delimiter = ',') {
            return data == null ? null : string.Join(delimiter, data);
        }

        public static string Vector3(Vector3 data) {
            return $"{data.X},{data.Y},{data.Z}";
        }

        public static string Color(Color data) {
            return $"0x{data.A:x2}{data.B:x2}{data.G:x2}{data.R:x2}";
        }
    }
}