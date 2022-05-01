using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Xml.Skill.Property;

namespace Maple2.File.Parser.Xml.Skill;

// ./data/xml/skill/%02d/%08u.xml
[XmlRoot("ms2")]
public partial class SkillData : IFeatureLocale {
    [M2dFeatureLocale] private Basic _basic;
    [M2dFeatureLocale(Selector = "value")] private IList<SkillLevelData> _level;
}

public partial class SkillLevelData : IFeatureLocale {
    [XmlAttribute] public short value;

    [XmlElement] public BeginCondition beginCondition;
    [XmlElement] public ChangeSkill changeSkill;
    [XmlElement] public MagicControl magicControl;
    [XmlElement] public AutoTargeting autoTargeting;
    [XmlElement] public Push push;
    [XmlElement] public Consume consume;
    [XmlElement] public TargetItem targetItem;
    [XmlElement] public Upgrade upgrade;
    [XmlElement] public RegionSkill detectProperty;
    [XmlElement] public RegionSkill sensorProperty;
    [XmlElement] public SplashManualActiveProperty splashManualActiveProperty;
    [XmlElement] public SkillGlideData glideProperty;
    [XmlElement] public Combo combo;
    [XmlElement] public RecoveryProperty recoveryProperty;
    [XmlElement] public List<TriggerSkill> conditionSkill;
    [XmlElement] public List<SkillMotionData> motion;
}

public class SkillGlideData {
    [XmlAttribute] public float gravity;
    [XmlAttribute] public float heightLimit;
    [XmlAttribute] public float horizontalAccelerate;
    [XmlAttribute] public float horizontalVelocity;
    [XmlAttribute] public float verticalAccelerate;
    [XmlAttribute] public float verticalVelocity;
    [XmlAttribute] public float verticalVibrateAmplitude;
    [XmlAttribute] public float verticalVibrateFrequency;
    [XmlAttribute] public float glideVerticalAccelerateLimit;
    [XmlAttribute] public float glideHorizontalAccelerateLimit;
    [XmlAttribute] public bool bEffect;
    [XmlAttribute] public string effectRun = string.Empty;
    [XmlAttribute] public string effectIdle = string.Empty;
    [XmlAttribute] public string aniIdle = string.Empty;
    [XmlAttribute] public string aniLeft = string.Empty;
    [XmlAttribute] public string aniRight = string.Empty;
    [XmlAttribute] public string aniRun = string.Empty;
    [XmlAttribute] public bool onGroundDisable;
}

public class SkillMotionData {
    [XmlElement] public List<SkillMotionProperty> motionProperty;
    [XmlElement] public List<SkillAttackData> attack;
}

public partial class SkillMotionProperty {
    [XmlAttribute] public string sequenceName = string.Empty;
    [XmlAttribute] public string motionEffect = string.Empty;
    [XmlAttribute] public string loopEffect = string.Empty;
    [XmlAttribute] public string endEffect = string.Empty;
    [XmlAttribute] public string splashInvokeEffect = string.Empty;
    [XmlAttribute] public string splashEndEffect = string.Empty;
    [M2dArray] public string[] strTagEffects = Array.Empty<string>();
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
}

public partial class SkillAttackData {
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
    [M2dArray] public int[] compulsionType = Array.Empty<int>();
    [XmlAttribute] public int grabTargetType;
    [M2dArray] public string[] grabNodeCategory = Array.Empty<string>();

    [XmlElement] public PetTamingProperty petTamingProperty;
    [XmlElement] public SplashManualActiveProperty splashManualActiveProperty;
    [XmlElement] public PauseProperty pauseProperty;
    [XmlElement] public RegionSkill rangeProperty;
    [XmlElement] public ChainProperty chainProperty;
    [XmlElement] public ArrowProperty arrowProperty;
    [XmlElement] public DamageProperty damageProperty;
    [XmlElement] public List<TriggerSkill> conditionSkill;

    // Ignored by client.
    [XmlAttribute] public string compulsionHit = string.Empty;
}
