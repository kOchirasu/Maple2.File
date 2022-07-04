using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Riding;

public class Shadow {
    [XmlAttribute] public float scale = 100.0f;
    [XmlAttribute] public float bias = 5.0f;
}
