using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Pet {
    public class Skill {
        [XmlAttribute] public int id;
        [XmlAttribute] public short level = 1;
    }
}