using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Common;

namespace Maple2.File.Parser.Xml.Skill {
    public class BeginCondition {
        [XmlAttribute] public int level = 1;
        [XmlAttribute] public long money;
        [XmlAttribute] public int gender = 2;
        [XmlAttribute] public bool target;
        [XmlAttribute] public float probability = 1.0f;
        [XmlAttribute] public float invokeEffectFactor = 1.0f;
        [XmlAttribute] public float cooldownTime;
        [XmlAttribute] public float defaultRechardingCooldownTime;
        [XmlAttribute] public bool useCoolDownShowUI;
        [XmlAttribute] public int allowDeadState;
        [XmlAttribute] public float requireDurationWithoutDamage;
        [XmlAttribute] public float requireDurationWithoutMove;
        [XmlAttribute] public bool useTargetCountFactor;
        [XmlAttribute] public bool onlyShadowWorld;
        [XmlAttribute] public bool onlyFlyableMap;
        [XmlAttribute] public int applyPvPZoneType;
        [XmlAttribute] public bool allowBattleRidingState;
        [XmlAttribute] public bool onlyBattleRidingState;
        [XmlAttribute] public bool allowMapleSurvival;

        [XmlElement] public List<Job> job;
        [XmlElement] public List<Effect> requireEffect;
        [XmlElement] public List<SkillElement> requireSkillElement;
        [XmlElement] public List<MapCodes> requireMapCodes;
        [XmlElement] public List<MapCategoryCodes> requireMapCategoryCodes;
        [XmlElement] public List<MapContinentCodes> requireMapContinentCodes;
        [XmlElement] public List<DungeonRoomGroupTypes> requireDungeonRoomGroupTypes;
        [XmlElement] public List<SkillCodes> requireSkillCodes;
        [XmlElement] public List<HasNotAdditionalEffectGroup> hasNotAdditionalEffectGroup;
        [XmlElement] public List<AchieveCodes> requireAchieveCodes;
        [XmlElement] public List<AchieveGrades> requireAchieveGrades;
        [XmlElement] public StatValue stat;
        [XmlElement] public List<Item> item;
        [XmlElement] public List<Weapon> weapon;
        [XmlElement("owner")] public SubConditionTarget skillOwner;
        [XmlElement("caster")] public SubConditionTarget skillCaster;
        [XmlElement("target")] public SubConditionTarget skillTarget;

        // Ignored by client.
        [XmlAttribute] public float defaultRechargingCooldownTime;
        [XmlAttribute] public bool isShadowWorld;
        [XmlAttribute] public bool glideOnGroundDisable;

        public class Job {
            [XmlAttribute] public int code;
        }

        public class Effect {
            [XmlAttribute] public int code;
        }

        public class SkillElement {
            [XmlAttribute] public int element;
        }

        public class MapCodes {
            [XmlAttribute] public int code;
        }

        public class MapCategoryCodes {
            [XmlAttribute] public int code;
        }

        public class MapContinentCodes {
            [XmlAttribute] public int code;
        }

        public class DungeonRoomGroupTypes {
            [XmlAttribute] public string type = string.Empty;
        }

        public class SkillCodes {
            [XmlAttribute] public int code;
        }

        public class HasNotAdditionalEffectGroup {
            [XmlAttribute] public int id;
        }

        public class AchieveCodes {
            [XmlAttribute] public int id;
        }

        public class AchieveGrades {
            [XmlAttribute] public int grade;
        }

        public class Item {
            [XmlAttribute] public int id;
            [XmlAttribute] public int count;
            [XmlAttribute] public int rank;
        }

        public class Weapon {
            [XmlAttribute] public int lh;
            [XmlAttribute] public int rh;
        }
    }
}
