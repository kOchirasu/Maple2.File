using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.String;

public class Key {
    [XmlAttribute] public string feature = string.Empty;

    [XmlAttribute] public string name = string.Empty;
    [XmlAttribute] public int id;
}
