using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Quest;

public class GotoNpc {
    [XmlAttribute] public bool enable;
    [XmlAttribute] public int gotoField;
    [XmlAttribute] public int gotoPortal;
}

public class GotoDungeon {
    [XmlAttribute] public int state; // 0,1,3
    [XmlAttribute] public int gotoDungeon;
    [XmlAttribute] public int gotoInstanceID;
}
