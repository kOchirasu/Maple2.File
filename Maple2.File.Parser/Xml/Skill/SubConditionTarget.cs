using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Skill {
    public class SubConditionTarget {
        [XmlIgnore] public int[] hasBuffID = Empty<int>();
        [XmlAttribute] public int multiHasBuffID;
        [XmlIgnore] public int[] hasBuffLevel = Empty<int>();
        [XmlIgnore] public int[] hasBuffOwner = Empty<int>();
        [XmlIgnore] public int[] checkActivateBuff = Empty<int>();
        [XmlIgnore] public int[] hasBuffCount = Empty<int>(); // csv map?
        [XmlIgnore] public string[] hasBuffCountCompare = Empty<string>(); // csv map?
        [XmlAttribute] public int eventCondition;
        [XmlAttribute] public int hasSkillID;
        [XmlAttribute] public short hasSkillLevel;
        [XmlAttribute] public int ignoreOwnerEvent;
        [XmlIgnore] public int[] hasNotBuffID = Empty<int>();
        [XmlAttribute] public int multiHasNotBuffID;
        [XmlAttribute] public int hasBuffOverlapGroup;
        [XmlIgnore] public int[] eventSkillID = Empty<int>();
        [XmlIgnore] public int[] eventIgnoreSkillID = Empty<int>();
        [XmlIgnore] public int[] eventEffectID = Empty<int>();
        [XmlIgnore] public string[] NpcRaceString = Empty<string>();
        [XmlIgnore] public int[] NpcRanks = Empty<int>();
        [XmlIgnore] public int[] NpcIDs = Empty<int>();
        [XmlAttribute] public int targetCheckRange;
        [XmlAttribute] public int targetCheckMinRange;
        [XmlAttribute] public int targetInRangeCount;
        [XmlAttribute] public int targetFriendly;
        [XmlAttribute] public string targetCountSign = string.Empty;
        [XmlIgnore] public string[] requireStates = Empty<string>();
        [XmlIgnore] public string[] requireSubStates = Empty<string>();
        [XmlIgnore] public string[] requireMasteryTypes = Empty<string>();
        [XmlIgnore] public int[] requireMasteryValues = Empty<int>();

        [XmlElement] public List<CompareRange> compareStat;

        /* Custom Attribute Serializers */
        [XmlAttribute("hasBuffID")]
        public string _hasBuffID {
            get => Serialize.IntCsv(hasBuffID);
            set => hasBuffID = Deserialize.IntCsv(value);
        }

        [XmlAttribute("hasBuffLevel")]
        public string _hasBuffLevel {
            get => Serialize.IntCsv(hasBuffLevel);
            set => hasBuffLevel = Deserialize.IntCsv(value);
        }

        [XmlAttribute("hasBuffOwner")]
        public string _hasBuffOwner {
            get => Serialize.IntCsv(hasBuffOwner);
            set => hasBuffOwner = Deserialize.IntCsv(value);
        }

        [XmlAttribute("checkActivateBuff")]
        public string _checkActivateBuff {
            get => Serialize.IntCsv(checkActivateBuff);
            set => checkActivateBuff = Deserialize.IntCsv(value);
        }

        [XmlAttribute("hasBuffCount")]
        public string _hasBuffCount {
            get => Serialize.IntCsv(hasBuffCount);
            set => hasBuffCount = Deserialize.IntCsv(value);
        }

        [XmlAttribute("hasBuffCountCompare")]
        public string _hasBuffCountCompare { // CompareType
            get => Serialize.StringCsv(hasBuffCountCompare);
            set => hasBuffCountCompare = Deserialize.StringCsv(value);
        }

        [XmlAttribute("hasNotBuffID")]
        public string _hasNotBuffID {
            get => Serialize.IntCsv(hasNotBuffID);
            set => hasNotBuffID = Deserialize.IntCsv(value);
        }

        [XmlAttribute("eventSkillID")]
        public string _eventSkillID {
            get => Serialize.IntCsv(eventSkillID);
            set => eventSkillID = Deserialize.IntCsv(value);
        }

        [XmlAttribute("eventIgnoreSkillID")]
        public string _eventIgnoreSkillID {
            get => Serialize.IntCsv(eventIgnoreSkillID);
            set => eventIgnoreSkillID = Deserialize.IntCsv(value);
        }

        [XmlAttribute("eventEffectID")]
        public string _eventEffectID {
            get => Serialize.IntCsv(eventEffectID);
            set => eventEffectID = Deserialize.IntCsv(value);
        }

        [XmlAttribute("NpcRaceString")]
        public string _NpcRaceString {
            get => Serialize.StringCsv(NpcRaceString);
            set => NpcRaceString = Deserialize.StringCsv(value);
        }

        [XmlAttribute("NpcRanks")]
        public string _NpcRanks {
            get => Serialize.IntCsv(NpcRanks);
            set => NpcRanks = Deserialize.IntCsv(value);
        }

        [XmlAttribute("NpcIDs")]
        public string _NpcIDs {
            get => Serialize.IntCsv(NpcIDs);
            set => NpcIDs = Deserialize.IntCsv(value);
        }

        [XmlAttribute("requireStates")]
        public string _requireStates { // ObjectState
            get => Serialize.StringCsv(requireStates);
            set => requireStates = Deserialize.StringCsv(value);
        }

        [XmlAttribute("requireSubStates")]
        public string _requireSubStates {
            get => Serialize.StringCsv(requireSubStates);
            set => requireSubStates = Deserialize.StringCsv(value);
        }

        [XmlAttribute("requireMasteryTypes")]
        public string _requireMasteryTypes { // MasteryType
            get => Serialize.StringCsv(requireMasteryTypes);
            set => requireMasteryTypes = Deserialize.StringCsv(value);
        }

        [XmlAttribute("requireMasteryValues")]
        public string _requireMasteryValues {
            get => Serialize.IntCsv(requireMasteryValues);
            set => requireMasteryValues = Deserialize.IntCsv(value);
        }
    }
}