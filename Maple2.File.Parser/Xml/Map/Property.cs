using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Map {
    public class Property {
        [XmlAttribute] public int mapCategoryCode;
        [XmlAttribute] public int revivalreturnid; // mapId if 0
        [XmlAttribute] public int enterreturnid;
        [XmlAttribute] public int capacity;
        [XmlAttribute] public int channelGroupID;
        [XmlAttribute] public int enterAdminLevel;
        [XmlAttribute] public short enterMinLevel;
        [XmlAttribute] public short enterMaxLevel;
        [XmlAttribute] public int massiveEventField;
        [XmlAttribute] public int recoveryFullHP;
        [XmlAttribute] public int continentCode;
        [XmlAttribute] public int regionCode;
        [XmlAttribute] public int useTimeEvent;
        [XmlAttribute] public int homeReturnable = 1;
        [XmlAttribute] public int deathPenalty = 1;
        [XmlAttribute] public int minimapInvisible;
        [XmlAttribute] public int autoRevivalType;
        [XmlAttribute] public int autoRevivalTime;
        [XmlAttribute] public int onlyDarkTomb;
        [XmlAttribute] public int pkMode;
        [XmlAttribute] public int webFinder;
        [XmlAttribute] public int checkFly;
        [XmlAttribute] public int checkClimb = 1;
        [XmlAttribute] public int limitMove;
        [XmlAttribute] public int checkPartyObserve;
        [XmlAttribute] public int doNotRevivalHere;
        [XmlAttribute] public float cubeSkillIntervalTime;
        [XmlAttribute] public int limitContent;
        [XmlAttribute] public bool mapSearch = true;
        [XmlAttribute] public int mapType;
        [XmlAttribute] public int infinityMeratRevival = 1;
        [XmlAttribute] public int bigCity;
        [XmlAttribute] public int exploreType;
        [XmlAttribute] public int tutorialType;
        [XmlAttribute] public int requireQuest;
        [XmlAttribute] public bool minimapPing;
        [XmlAttribute] public bool popupMenu = true;
        [XmlAttribute] public bool gemSystem = true;
        [XmlIgnore] public int[] skillUseDisable = Empty<int>();
        [XmlIgnore] public int[] enteranceBuffIDs = Empty<int>();
        [XmlIgnore] public int[] enteranceBuffLevels = Empty<int>();
        [XmlIgnore] public string[] propertyTags = Empty<string>();

        /* Custom Attribute Serializers */
        [XmlAttribute("skillUseDisable")]
        public string _skillUseDisable {
            get => Serialize.IntCsv(skillUseDisable);
            set => skillUseDisable = Deserialize.IntCsv(value);
        }

        [XmlAttribute("enteranceBuffIDs")]
        public string _enteranceBuffIDs {
            get => Serialize.IntCsv(enteranceBuffIDs);
            set => enteranceBuffIDs = Deserialize.IntCsv(value);
        }

        [XmlAttribute("enteranceBuffLevels")]
        public string _enteranceBuffLevels {
            get => Serialize.IntCsv(enteranceBuffLevels);
            set => enteranceBuffLevels = Deserialize.IntCsv(value);
        }

        [XmlAttribute("propertyTags")]
        public string _propertyTags {
            get => Serialize.StringCsv(propertyTags);
            set => propertyTags = Deserialize.StringCsv(value);
        }

        // Ignored by client.
        [XmlAttribute] public int additionalUseDisable;
        [XmlAttribute] public int ignoreFindParty;
    }
}