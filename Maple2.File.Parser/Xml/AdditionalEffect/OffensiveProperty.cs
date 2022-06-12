using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public class OffensiveProperty {
    [XmlAttribute] public long papDamageV;
    [XmlAttribute] public float papDamageR;
    [XmlAttribute] public long mapDamageV;
    [XmlAttribute] public float mapDamageR;
    [XmlAttribute] public int attackSuccessCritical; // 0
    [XmlAttribute] public int hitImmuneBreak; // 0,1,5
}
