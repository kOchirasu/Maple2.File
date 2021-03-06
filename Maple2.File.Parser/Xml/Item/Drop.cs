using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item {
    public class Drop {
        [XmlAttribute] public string dropNif;
        [XmlAttribute] public string dropDisplay;
        // unknown delimited by '.'
    }
}