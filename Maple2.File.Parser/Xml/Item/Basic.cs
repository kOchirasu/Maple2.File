using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Item {
    public class Basic {
        [XmlAttribute] public int originID;
        [XmlAttribute] public int friendly = 1;
        [XmlAttribute] public string stringTag;
        [XmlIgnore] public string[] attributeTag;

        /* Custom Attribute Serializers */
        [XmlAttribute("attributeTag")]
        public string _attributeTag {
            get => Serialize.StringCsv(attributeTag);
            set => attributeTag = Deserialize.StringCsv(value);
        }
    }
}