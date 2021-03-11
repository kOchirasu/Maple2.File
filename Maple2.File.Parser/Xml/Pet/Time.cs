using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Pet {
    public class Time {
        [XmlAttribute] public int idle;
        [XmlAttribute] public int bore;
        [XmlAttribute] public int summonCast;
        [XmlAttribute] public int tired;
        [XmlAttribute] public int skill;
        [XmlAttribute] public int PetSlotNum;
    }
}