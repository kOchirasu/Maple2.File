using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item {
    public class Housing {
        [XmlAttribute] public int filter = 100;
        [XmlAttribute] public int categoryIndex = 10000;
        [XmlAttribute] public string categoryTag;
        [XmlAttribute] public int trophyID;
        [XmlAttribute] public int trophyLevel = 1;
        [XmlAttribute] public int interiorLevel = 1;
        [XmlAttribute] public int setItemID;
        [XmlAttribute] public bool doNotInstallBlueprint;
    }
}