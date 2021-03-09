using System;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Item {
    public class Basic {
        [XmlAttribute] public int originID;
        [XmlAttribute] public int friendly = 1;
        [XmlAttribute] public string stringTag = string.Empty;
        [XmlIgnore] public string[] attributeTag = Array.Empty<string>();

        /* Custom Attribute Serializers */
        [XmlAttribute("attributeTag")]
        public string _attributeTag {
            get => Serialize.StringCsv(attributeTag);
            set => attributeTag = Deserialize.StringCsv(value);
        }
    }
}