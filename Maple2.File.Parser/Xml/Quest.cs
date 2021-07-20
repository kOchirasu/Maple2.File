using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Xml.Quest;

namespace Maple2.File.Parser.Xml {
    // ./data/xml/quest/%08d.xml
    [XmlRoot("ms2")]
    public class QuestEnvironmentData {
        [XmlElement] public List<QuestDataRoot> environment;
    }

    public class QuestDataRoot {
        [XmlAttribute] public string feature = string.Empty;
        [XmlAttribute] public string locale = string.Empty;

        [XmlElement] public QuestData quest;
    }

    public partial class QuestData {
        [XmlElement] public Basic basic;
        [XmlElement] public Notify notify;
        [XmlElement] public Require require;

        [XmlElement] public List<Condition> condition;

        //[XmlElement] public Navigation navi;
        [XmlElement] public Start start;
        [XmlElement] public Complete complete;
        [XmlElement] public Reward completeReward;
        [XmlElement] public Reward acceptReward;
        [XmlElement] public ProgressMap progressMap;
        [XmlElement] public Guide guide;
        [XmlElement] public EventMission eventMission;
        [XmlElement] public MentoringMission mentoringMission;
        [XmlElement] public Dispatch dispatch;
        [XmlElement] public GotoNpc gotoNpc;
        [XmlElement] public GotoDungeon gotoDungeon;
        [XmlElement] public Remote remoteAccept;
        [XmlElement] public Remote remoteComplete;
        [XmlElement] public SummonPortal summonPortal;

        public class Start {
            [XmlAttribute] public int npc;
        }

        public partial class Complete {
            [XmlAttribute] public int npc;

            [XmlAttribute]
            public string type = NavigationType.unknown.ToString(); // Navigation type: default = unknown(3)

            [M2dArray] public int[] code = Array.Empty<int>();
            [M2dArray] public int[] map = Array.Empty<int>();

            // Ignored by client.
            [XmlAttribute] public int fieldID;
        }
    }
}
