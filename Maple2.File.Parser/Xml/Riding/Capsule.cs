using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Riding;

public class Capsule {
    [XmlAttribute] public float radius;
    [XmlAttribute] public float height;
}
