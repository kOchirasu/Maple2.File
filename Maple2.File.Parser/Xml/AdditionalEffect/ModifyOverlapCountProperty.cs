using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class ModifyOverlapCountProperty {
        [XmlIgnore] public int[] effectCodes; // csv
        [XmlIgnore] public int[] offsetCounts; // csv

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