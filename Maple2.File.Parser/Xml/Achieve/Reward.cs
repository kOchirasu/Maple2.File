using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Achieve {
    public partial class Reward {
        [XmlAttribute] public string type = string.Empty; // AchieveRewardType
        [XmlAttribute] public int code;
        [XmlAttribute] public int value;
        [XmlAttribute] public int rank = 1;
        [XmlAttribute] public int subJobLevel;
        [M2dArray] public string[] extra = Array.Empty<string>(); // split on ',' and ':'?
    }
}
