using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Item {
    public class AdditionalEffect {
        [XmlIgnore] public int[] id = Empty<int>();
        [XmlIgnore] public int[] level = Empty<int>();
        [XmlAttribute] public bool dropEffect;

        /* Custom Attribute Serializers */
        [XmlAttribute("id")]
        public string _id {
            get => Serialize.IntCsv(id);
            set => id = Deserialize.IntCsv(value);
        }

        [XmlAttribute("level")]
        public string _level {
            get => Serialize.IntCsv(level);
            set => level = Deserialize.IntCsv(value);
        }
    }
}