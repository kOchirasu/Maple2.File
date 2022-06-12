using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public class SpecialEffectProperty {
    [XmlAttribute] public int type; // 2,3,4,5,6,7,8,9,10,11,12,13
    [XmlAttribute] public float probability;
    [XmlAttribute] public string values = string.Empty;
    [XmlAttribute] public string activateMsg = string.Empty;
}
