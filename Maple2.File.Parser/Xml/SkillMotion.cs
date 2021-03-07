using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Skill;
using Maple2.File.Parser.Xml.Skill.Property;
using static System.Array;

namespace Maple2.File.Parser.Xml {
    public class SkillMotionData {
        [XmlElement] public List<SkillMotionProperty> motionProperty;
        [XmlElement] public List<SkillAttackData> attack;
    }

    public class SkillMotionProperty {
        [XmlAttribute] public string sequenceName = string.Empty;
        [XmlAttribute] public string motionEffect = string.Empty;
        [XmlAttribute] public string loopEffect = string.Empty;
        [XmlAttribute] public string endEffect = string.Empty;
        [XmlAttribute] public string splashInvokeEffect = string.Empty;
        [XmlAttribute] public string splashEndEffect = string.Empty;
        [XmlIgnore] public string[] strTagEffects = Empty<string>();
        [XmlAttribute] public string selfInputCombo = string.Empty;
        [XmlAttribute] public string weaponSequenceName = string.Empty;
        [XmlAttribute] public string loopKeepEffect = string.Empty;
        [XmlAttribute] public string loopEndEffect = string.Empty;
        [XmlAttribute] public string splashDurationCastEffect = string.Empty;
        [XmlAttribute] public bool IgnoreOptimalHideCastEffect;
        [XmlAttribute] public bool IgnoreOptimalHideEndEffect;
        [XmlAttribute] public bool IgnoreOptimalHideSplashInvokeEffect;
        [XmlAttribute] public bool IgnoreOptimalHideSplashEndEffect;
        [XmlAttribute] public bool splashCastEffectStartDelay;
        [XmlAttribute] public int splashLifeTick;
        [XmlAttribute] public int splashInvokeCoolTick;
        [XmlAttribute] public float sequenceSpeed;
        [XmlAttribute] public float keyMove;
        [XmlAttribute] public int movetype;
        [XmlAttribute] public float moveangle;
        [XmlAttribute] public float movevangle;
        [XmlAttribute] public float movedistance;
        [XmlAttribute] public int moveEaseType;
        [XmlAttribute] public float moveMid;
        [XmlAttribute] public float moveHeight;
        [XmlAttribute] public int hide;
        [XmlAttribute] public int ignoreCollisionGroups;
        [XmlAttribute] public int holdWeapon;
        [XmlAttribute] public int loopCount;
        [XmlAttribute] public int faceTarget;
        [XmlAttribute] public bool doesPlayIdleOnSkillEnd;
        [XmlAttribute] public int startNoneBlendDelay;
        [XmlAttribute] public bool ignoreASP;
        [XmlAttribute] public float pushCylinderVelH;
        [XmlAttribute] public float pushCylinderVelV;
        [XmlAttribute] public float pushCylinderOuter;
        [XmlAttribute] public float pushCylinderInner;
        [XmlAttribute] public float pushCylinderHeight;
        [XmlAttribute] public float aniSkipTime;

        /* Custom Attribute Serializers */
        [XmlAttribute("strTagEffects")]
        public string _strTagEffects {
            get => Serialize.StringCsv(strTagEffects);
            set => strTagEffects = Deserialize.StringCsv(value);
        }
    }

    public class SkillAttackData {
        [XmlAttribute] public string point = string.Empty;
        [XmlAttribute] public int pointGroupID;
        [XmlAttribute] public int targetCount;
        [XmlAttribute] public int magicPathID;
        [XmlAttribute] public int cubeMagicPathID;
        [XmlAttribute] public int direction = 3;
        [XmlAttribute] public int sequence;
        [XmlAttribute] public int attacktype;
        [XmlAttribute] public int attackMethodType;
        [XmlAttribute] public int hitImmuneBreak;
        [XmlAttribute] public float brokenForce;
        [XmlAttribute] public int brokenOffence;
        [XmlAttribute] public int unrideOnHit;
        [XmlAttribute] public int releaseObjectWeaponOnHit = 1;
        [XmlIgnore] public int[] compulsionType = Empty<int>();
        [XmlAttribute] public int grabTargetType;
        [XmlIgnore] public string[] grabNodeCategory = Empty<string>();

        [XmlElement] public PetTamingProperty petTamingProperty;
        [XmlElement] public SplashManualActiveProperty splashManualActiveProperty;
        [XmlElement] public PauseProperty pauseProperty;
        [XmlElement] public RegionSkill rangeProperty;
        [XmlElement] public ChainProperty chainProperty;
        [XmlElement] public ArrowProperty arrowProperty;
        [XmlElement] public DamageProperty damageProperty;
        [XmlElement] public List<TriggerSkill> conditionSkill;

        /* Custom Attribute Serializers */
        [XmlAttribute("compulsionType")]
        public string _compulsionType {
            get => Serialize.IntCsv(compulsionType);
            set => compulsionType = Deserialize.IntCsv(value);
        }

        [XmlAttribute("grabNodeCategory")]
        public string _grabNodeCategory { // NodeCategory
            get => Serialize.StringCsv(grabNodeCategory);
            set => grabNodeCategory = Deserialize.StringCsv(value);
        }

        // Ignored by client.
        [XmlAttribute] public string compulsionHit = string.Empty;
    }
}