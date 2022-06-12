using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public class ShieldProperty {
    [XmlAttribute] public long hpValue;
    [XmlAttribute] public float hpByTargetMaxHP;
    [XmlAttribute] public int uiType; // 0,3
    [XmlAttribute] public int uiTypeValue; // 0,50001354,60300016,60300114
}
