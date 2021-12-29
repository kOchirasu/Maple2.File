using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Xml.Script;

namespace Maple2.File.Parser.Xml; 

// ./data/xml/script/npc/%08d.xml
[XmlRoot("ms2")]
public class NpcScript {
    [XmlElement] public List<TalkScript> select;
    [XmlElement] public TalkScript job;
    [XmlElement] public List<TalkScript> monologue;
    [XmlElement] public List<TalkScript> script;
}

// ./data/xml/script/quest/%s.xml
[XmlRoot("ms2")]
public class QuestScriptRoot {
    [XmlElement] public List<QuestScript> quest;
}

public class QuestScript {
    [XmlAttribute] public int id;

    [XmlElement] public List<TalkScript> script;
}

public partial class TalkScript {
    [XmlAttribute] public string feature = string.Empty;
    [XmlAttribute] public string locale = string.Empty;

    [XmlAttribute] public int id;
    [XmlAttribute] public bool randomPick;
    [XmlAttribute] public int popupProp;
    [XmlAttribute] public int popupState;
    [M2dArray] public int[] gotoConditionTalkID;
    [XmlAttribute] public int jobCondition;

    [XmlElement] public List<Content> content;

    // Ignored by client.
    //[XmlAttribute] public string buttonSet; // "roulette"
    //[XmlAttribute] public string tag; // "limitFameGrade"
}