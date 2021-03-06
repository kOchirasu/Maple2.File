using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class ShieldProperty {
        [XmlAttribute] public long hpValue;
        [XmlAttribute] public float hpByTargetMaxHP;
        [XmlAttribute] public int uiType;
        [XmlAttribute] public int uiTypeValue;
    }
}