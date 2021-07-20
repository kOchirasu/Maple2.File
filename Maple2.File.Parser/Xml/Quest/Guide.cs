using System.Xml.Serialization;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest {
    public class Guide {
        [XmlAttribute] public string guideType = string.Empty; // GuideType
        [XmlAttribute] public string guideGroup = GuideGroup.unknown.ToString(); // GuideGroup
        [XmlAttribute] public string guideIcon = string.Empty;
        [XmlAttribute] public short guideMinLevel;
        [XmlAttribute] public short guideMaxLevel;
    }
}
