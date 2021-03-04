using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Stat;

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

        [XmlElement] public List<RequireJob> job;
        [XmlElement] public List<RequireEffect> requireEffect;
        [XmlElement] public List<RequireSkillElement> requireSkillElement;
        [XmlElement] public List<RequireMapCodes> requireMapCodes;
        [XmlElement] public List<RequireMapCategoryCodes> requireMapCategoryCodes;
        [XmlElement] public List<RequireMapContinentCodes> requireMapContinentCodes;
        [XmlElement] public List<RequireDungeonRoomGroupTypes> requireDungeonRoomGroupTypes;
        [XmlElement] public List<RequireSkillCodes> requireSkillCodes;
        [XmlElement] public List<HasNotAdditionalEffectGroup> hasNotAdditionalEffectGroup;
        [XmlElement] public List<RequireAchieveCodes> requireAchieveCodes;
        [XmlElement] public List<RequireAchieveGrades> requireAchieveGrades;
        [XmlElement] public StatValue stat;
        [XmlElement] public List<RequireItem> item;
        [XmlElement] public List<RequireWeapon> weapon;
        [XmlElement("owner")] public SubConditionTarget skillOwner;
        [XmlElement("caster")] public SubConditionTarget skillCaster;
        [XmlElement("target")] public SubConditionTarget skillTarget;

        // Ignored by client.
        [XmlAttribute] public float defaultRechargingCooldownTime;
        [XmlAttribute] public bool isShadowWorld;
        [XmlAttribute] public bool glideOnGroundDisable;
    }

    public class RequireJob {
        [XmlAttribute] public int code;
    }

    public class RequireEffect {
        [XmlAttribute] public int code;
    }

    public class RequireSkillElement {
        [XmlAttribute] public int element;
    }

    public class RequireMapCodes {
        [XmlAttribute] public int code;
    }

    public class RequireMapCategoryCodes {
        [XmlAttribute] public int code;
    }

    public class RequireMapContinentCodes {
        [XmlAttribute] public int code;
    }

    public class RequireDungeonRoomGroupTypes {
        [XmlAttribute] public string type;
    }

    public class RequireSkillCodes {
        [XmlAttribute] public int code;
    }

    public class HasNotAdditionalEffectGroup {
        [XmlAttribute] public int id;
    }

    public class RequireAchieveCodes {
        [XmlAttribute] public int id;
    }

    public class RequireAchieveGrades {
        [XmlAttribute] public int grade;
    }

    public class RequireItem {
        [XmlAttribute] public int id;
        [XmlAttribute] public int count;
        [XmlAttribute] public int rank;
    }

    public class RequireWeapon {
        [XmlAttribute] public int lh;
        [XmlAttribute] public int rh;
    }
}