using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Stat;

namespace Maple2.File.Parser.Xml.Skill {
    public class Consume {
        [XmlAttribute] public long money;
        [XmlAttribute] public bool useItem;
        [XmlAttribute] public float hpRate;

        [XmlElement] public StatValue stat;
    }
}