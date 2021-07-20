using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Pet {
    public class Distance {
        [XmlAttribute] public float pick;
        [XmlAttribute] public float warp;
        [XmlAttribute] public float trace;
        [XmlAttribute] public float battleTrace;
    }
}
