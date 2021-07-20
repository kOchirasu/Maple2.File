using System.Drawing;

namespace Maple2.File.Parser.Tools {
    internal static class Serialize {
        public static string Color(Color data) {
            return $"0x{data.A:x2}{data.B:x2}{data.G:x2}{data.R:x2}";
        }
    }
}
