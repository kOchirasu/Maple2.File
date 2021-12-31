using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest;

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
    [M2dEnum] public AllianceType alliance = AllianceType.unknown;
    [M2dEnum] public AllianceRank rank = AllianceRank.Unknown;
    [XmlAttribute] public bool usePostbox;
    [XmlAttribute] public bool useReEntryHiddenMap;
    [M2dEnum] public DayOfWeek usePeriod = DayOfWeek.unknown;
    [M2dArray] public QuestPropertyType[] property;
}