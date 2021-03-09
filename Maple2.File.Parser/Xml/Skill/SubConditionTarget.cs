using System.Collections.Generic;
using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill {
    public partial class SubConditionTarget {
        [M2dArray] public int[] hasBuffID = Array.Empty<int>();
        [XmlAttribute] public int multiHasBuffID;
        [M2dArray] public int[] hasBuffLevel = Array.Empty<int>();
        [M2dArray] public int[] hasBuffOwner = Array.Empty<int>();
        [M2dArray] public int[] checkActivateBuff = Array.Empty<int>();
        [M2dArray] public int[] hasBuffCount = Array.Empty<int>(); // csv map?
        [M2dArray] public string[] hasBuffCountCompare = Array.Empty<string>(); // csv map? CompareType
        [XmlAttribute] public int eventCondition;
        [XmlAttribute] public int hasSkillID;
        [XmlAttribute] public short hasSkillLevel;
        [XmlAttribute] public int ignoreOwnerEvent;
        [M2dArray] public int[] hasNotBuffID = Array.Empty<int>();
        [XmlAttribute] public int multiHasNotBuffID;
        [XmlAttribute] public int hasBuffOverlapGroup;
        [M2dArray] public int[] eventSkillID = Array.Empty<int>();
        [M2dArray] public int[] eventIgnoreSkillID = Array.Empty<int>();
        [M2dArray] public int[] eventEffectID = Array.Empty<int>();
        [M2dArray] public string[] NpcRaceString = Array.Empty<string>();
        [M2dArray] public int[] NpcRanks = Array.Empty<int>();
        [M2dArray] public int[] NpcIDs = Array.Empty<int>();
        [XmlAttribute] public int targetCheckRange;
        [XmlAttribute] public int targetCheckMinRange;
        [XmlAttribute] public int targetInRangeCount;
        [XmlAttribute] public int targetFriendly;
        [XmlAttribute] public string targetCountSign = string.Empty;
        [M2dArray] public string[] requireStates = Array.Empty<string>(); // ObjectState
        [M2dArray] public string[] requireSubStates = Array.Empty<string>();
        [M2dArray] public string[] requireMasteryTypes = Array.Empty<string>(); // MasteryType
        [M2dArray] public int[] requireMasteryValues = Array.Empty<int>();

        [XmlElement] public List<CompareRange> compareStat;
    }
}