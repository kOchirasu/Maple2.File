using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect; 

public class DefensiveProperty {
    [XmlAttribute] public long papDamageV;
    [XmlAttribute] public float papDamageR;
    [XmlAttribute] public long mapDamageV;
    [XmlAttribute] public float mapDamageR;
    [XmlAttribute] public int invincible;
}