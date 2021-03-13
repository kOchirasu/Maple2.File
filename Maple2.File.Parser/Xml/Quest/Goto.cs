using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Quest {
    public class GotoNpc {
        [XmlAttribute] public int enable;
        [XmlAttribute] public int gotoField;
        [XmlAttribute] public int gotoPortal;
    }

    public class GotoDungeon {
        [XmlAttribute] public int state;
        [XmlAttribute] public int gotoDungeon;
        [XmlAttribute] public int gotoInstanceID;
    }
}