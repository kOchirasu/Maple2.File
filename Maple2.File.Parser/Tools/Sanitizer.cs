using System.Text.RegularExpressions;

namespace Maple2.File.Parser.Tools {
    public static class Sanitizer {
        public static string SanitizeMagicPath(string xml) {
            // typos
            xml = xml.Replace("ldestroyTime", "destroyTime");
            xml = xml.Replace("ccontrolValue", "controlValue");
            xml = xml.Replace("fireoffsetPosition", "fireOffsetPosition");
            xml = xml.Replace("lifetime", "lifeTime");

            xml = FixCommaFloats(xml, "lifeTime", "delayTime", "spawnTime", "vel", "distance", "destroyTime", "controlRate");
            xml = Regex.Replace(xml, "(-?\\d+\\.\\d+)\\.\\d+", "$1"); // 1.2.3 -> 1.2
            return xml;
        }

        public static string SanitizeMap(string xml) {
            xml =  Regex.Replace(xml, "\\w+=\"\"", string.Empty);
            xml = xml.Replace("enterreturnid=\"Kritias_Epic03\"", "enterreturnid=\"52100304\"");
            xml = xml.Replace("enterreturnid=\"Develop\"", "enterreturnid=\"99999999\"");
            return xml;
        }

        // Floats using ',' are converted to '.' (1,2 -> 1.2)
        private static string FixCommaFloats(string xml, params string[] attributes) {
            string pattern = $"({string.Join('|', attributes)})=\"(-?\\d+)(?:,(\\d+))\"";
            return Regex.Replace(xml, pattern, "$1=\"$2.$3\"");
        }
    }
}