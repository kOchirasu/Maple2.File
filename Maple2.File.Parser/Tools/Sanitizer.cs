using System;
using System.Text.RegularExpressions;

namespace Maple2.File.Parser.Tools {
    public static class Sanitizer {
        public static string SanitizeMagicPath(string xml) {
            // typos
            xml = xml.Replace("ldestroyTime", "destroyTime");
            xml = xml.Replace("ccontrolValue", "controlValue");
            xml = xml.Replace("fireoffsetPosition", "fireOffsetPosition");
            xml = xml.Replace("lifetime", "lifeTime");

            xml = FixCommaFloats(xml, "lifeTime", "delayTime", "spawnTime", "vel", "distance", "destroyTime",
                "controlRate");
            xml = Regex.Replace(xml, "(-?\\d+\\.\\d+)\\.\\d+", "$1"); // 1.2.3 -> 1.2
            return xml;
        }

        public static string SanitizeMap(string xml) {
            xml = RemoveEmpty(xml);
            xml = xml.Replace("enterreturnid=\"Kritias_Epic03\"", "enterreturnid=\"52100304\"");
            xml = xml.Replace("enterreturnid=\"Develop\"", "enterreturnid=\"99999999\"");
            return xml;
        }

        public static string SanitizeNpc(string xml) {
            int headerIndex = xml.IndexOf("<?xml", StringComparison.Ordinal);
            if (headerIndex != 0) {
                xml = xml.Substring(headerIndex);
            }

            if (!xml.Contains("<environment")) {
                xml = xml.Replace("<ms2>", "<ms2><environment>");
                xml = xml.Contains("<effectdummy")
                    ? xml.Replace("<effectdummy", "</environment><effectdummy")
                    : xml.Replace("</ms2>", "</environment></ms2>");
            }

            return xml;
        }

        public static string SanitizeQuest(string xml) {
            xml = RemoveEmpty(xml);
            xml = xml.Replace("TRUE", "true");
            xml = xml.Replace("FALSE", "false");
            return xml;
        }

        public static string RemoveEmpty(string xml) {
            return Regex.Replace(xml, "\\w+=\"\"", string.Empty);
        }

        // Floats using ',' are converted to '.' (1,2 -> 1.2)
        private static string FixCommaFloats(string xml, params string[] attributes) {
            string pattern = $"({string.Join('|', attributes)})=\"(-?\\d+)(?:,(\\d+))\"";
            return Regex.Replace(xml, pattern, "$1=\"$2.$3\"");
        }
    }
}
