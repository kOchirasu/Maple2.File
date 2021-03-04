using System.ComponentModel;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class BasicProperty {
        [XmlAttribute] public int level = 1; //?
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
        [XmlAttribute] public string coolDownTime;
        [XmlAttribute] public string clearDistanceFromCaster;
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
        [XmlAttribute, DefaultValue(0)] public int skillGroupType;
        [XmlIgnore] public int[] attackPossibleSkillIDs; // csv
        [XmlIgnore] public int[] attackPossibleDotEffectIDs; // csv
        [XmlIgnore] public int[] groupIDs; // csv
        [XmlAttribute] public int immediateActiveRequireSkill;
        [XmlIgnore] public int[] itemSlotDisable; // csv
        [XmlAttribute] public int tailEffect;
        [XmlIgnore] public int[] upgradeSkillLevelID; // csv
        [XmlIgnore] public int[] upgradeSkillLevelValue; // csv

        /* Custom Attribute Serializers */
        [XmlAttribute("attackPossibleSkillIDs")]
        public string _attackPossibleSkillIDs {
            get => Serialize.IntCsv(attackPossibleSkillIDs);
            set => attackPossibleSkillIDs = Deserialize.IntCsv(value);
        }

        [XmlAttribute("attackPossibleDotEffectIDs")]
        public string _attackPossibleDotEffectIDs {
            get => Serialize.IntCsv(attackPossibleDotEffectIDs);
            set => attackPossibleDotEffectIDs = Deserialize.IntCsv(value);
        }

        [XmlAttribute("groupIDs")]
        public string _groupIDs {
            get => Serialize.IntCsv(groupIDs);
            set => groupIDs = Deserialize.IntCsv(value);
        }

        [XmlAttribute("itemSlotDisable")]
        public string _itemSlotDisable {
            get => Serialize.IntCsv(itemSlotDisable);
            set => itemSlotDisable = Deserialize.IntCsv(value);
        }

        [XmlAttribute("upgradeSkillLevelID")]
        public string _upgradeSkillLevelID {
            get => Serialize.IntCsv(upgradeSkillLevelID);
            set => upgradeSkillLevelID = Deserialize.IntCsv(value);
        }

        [XmlAttribute("upgradeSkillLevelValue")]
        public string _upgradeSkillLevelValue {
            get => Serialize.IntCsv(upgradeSkillLevelValue);
            set => upgradeSkillLevelValue = Deserialize.IntCsv(value);
        }
    }
}