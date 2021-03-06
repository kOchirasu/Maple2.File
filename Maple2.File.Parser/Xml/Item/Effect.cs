using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item {
    public class Effect {
        [XmlAttribute] public int enchantShape = 1;
        [XmlAttribute] public string idle;
        [XmlAttribute] public string battleIdle;
        [XmlAttribute] public string characterIdle;
        [XmlAttribute] public string characterBattleIdle;
    }
}