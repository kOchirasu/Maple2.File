using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public partial class BasicProperty {
        [XmlAttribute] public short level = 1;
        [XmlAttribute] public int accountEffect;
        [XmlAttribute] public int group;
        [XmlAttribute] public int buffType = 1;
        [XmlAttribute] public int buffSubType;
        [XmlAttribute] public int buffCategory;
        [XmlAttribute] public int eventBuffType;
        [XmlAttribute] public int useInGameTime;
        [XmlAttribute] public int durationTick;
        [XmlAttribute] public int intervalTick;
        [XmlAttribute] public int delayTick;
        [XmlAttribute] public int keepCondition;
        [XmlAttribute] public int resetCondition;
        [XmlAttribute] public int maxBuffCount = 1;
        [XmlAttribute] public int dotCondition;
        [XmlAttribute] public int invokeEvent;
        [XmlAttribute] public int deadKeepEffect;
        [XmlAttribute] public int logoutClearEffect;
        [XmlAttribute] public int leaveFieldClearEffect;
        [XmlAttribute] public int pvpOnOff;
        [XmlAttribute] public int casterKeepEffect;
        [XmlAttribute] public int casterIndividualEffect;
        [XmlAttribute] public string coolDownTime = string.Empty;
        [XmlAttribute] public string clearDistanceFromCaster = string.Empty;
        [XmlAttribute] public int useInvokeEffectFactor;
        [XmlAttribute] public int clearEffectFromPVPZone;
        [XmlAttribute] public int doNotClearEffectFromEnterPVPZone;
        [XmlAttribute] public int clearCooldownFromPVPZone;
        [XmlAttribute] public int forceApplyTarget;
        [XmlAttribute] public int ignoreReduceTimeCondition;
        [XmlAttribute] public int skillSetID;
        [XmlAttribute] public int costumeSetID;
        [XmlAttribute] public int statSetID;
        [XmlAttribute] public int disableRevivalHere;
        [XmlAttribute] public int attackPossibleEffectID;
        [XmlAttribute] public int skillGroupType;
        [M2dArray] public int[] attackPossibleSkillIDs = Array.Empty<int>();
        [M2dArray] public int[] attackPossibleDotEffectIDs = Array.Empty<int>();
        [M2dArray] public int[] groupIDs = Array.Empty<int>();
        [XmlAttribute] public int immediateActiveRequireSkill;
        [M2dArray] public int[] itemSlotDisable = Array.Empty<int>();
        [XmlAttribute] public int tailEffect;
        [M2dArray] public int[] upgradeSkillLevelID = Array.Empty<int>();
        [M2dArray] public int[] upgradeSkillLevelValue = Array.Empty<int>();
    }
}