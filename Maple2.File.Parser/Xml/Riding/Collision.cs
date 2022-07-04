using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Riding;

public class Collision {
    [XmlAttribute] public string shape = string.Empty;
    [XmlAttribute] public float width;
    [XmlAttribute] public float height;
    [XmlAttribute] public float depth;
    [XmlAttribute] public bool physic;
}
