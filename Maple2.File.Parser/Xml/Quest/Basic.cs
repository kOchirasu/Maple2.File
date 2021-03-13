using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest {
    public partial class Basic {
        [XmlAttribute] public int chapterID;
        [XmlAttribute] public int questID;
        [XmlAttribute] public int standardLevel;
        [XmlAttribute] public int autoStart;
        [XmlAttribute] public int disableGiveup;
        [XmlAttribute] public int exceptChapterClear;
        [XmlAttribute] public int repeatable;
        [XmlAttribute] public int questType;
        [XmlAttribute] public int account;
        [XmlAttribute] public string eventTag = string.Empty;
        [XmlAttribute] public int locking;
        [XmlAttribute] public int tabIndex = -1;
        [XmlAttribute] public int forceRegistGuide;
        [XmlAttribute] public bool useNavi;
        [XmlAttribute] public string alliance = string.Empty; // AllianceType
        [XmlAttribute] public string rank = AllianceRank.Unknown.ToString(); // AllianceRank
        [XmlAttribute] public bool usePostbox;
        [XmlAttribute] public bool useReEntryHiddenMap;
        [XmlAttribute] public string usePeriod = DayOfWeek.unknown.ToString(); // DayOfWeek
        [M2dArray] public string[] property; // QuestPropertyType
    }
}