using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class SpecialEffectProperty {
        [XmlAttribute] public int type;
        [XmlAttribute] public float probability;
        [XmlAttribute] public string values = string.Empty;
        [XmlAttribute] public string activateMsg = string.Empty;
    }
}