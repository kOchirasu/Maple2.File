using System;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class ModifyOverlapCountProperty {
        [XmlIgnore] public int[] effectCodes = Array.Empty<int>();
        [XmlIgnore] public int[] offsetCounts = Array.Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("effectCodes")]
        public string _effectCodes {
            get => Serialize.IntCsv(effectCodes);
            set => effectCodes = Deserialize.IntCsv(value);
        }

        [XmlAttribute("offsetCounts")]
        public string _offsetCounts {
            get => Serialize.IntCsv(offsetCounts);
            set => offsetCounts = Deserialize.IntCsv(value);
        }
    }
}