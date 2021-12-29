using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect; 

public partial class MotionProperty {
    [XmlAttribute] public string sequenceName = string.Empty;
    [XmlAttribute] public string startEffect = string.Empty;
    [XmlAttribute] public string keepEffect = string.Empty;
    [XmlAttribute] public string stopEffect = string.Empty;
    [XmlAttribute] public string invokeEffect = string.Empty;
    [XmlAttribute] public bool IgnoreOptimalHideStartEffect;
    [XmlAttribute] public bool IgnoreOptimalHideKeepEffect;
    [XmlAttribute] public bool IgnoreOptimalHideStopEffect;
    [XmlAttribute] public bool IgnoreOptimalHideInvokeEffect;
    [M2dArray] public int[] disableEffectStates = Array.Empty<int>();
    [XmlAttribute] public int hide;
    [M2dArray] public int[] clearCondition = Array.Empty<int>();
    [XmlAttribute] public float alphaBlending = 1.0f;
    [XmlAttribute] public int stun;
    [XmlAttribute] public string stunAnimation = string.Empty;
    [XmlAttribute] public int confusionMove;
    [XmlAttribute] public int soundPitch;
    [XmlAttribute] public int abnormalImmuneBreak;
    [XmlAttribute] public int revival;
    [XmlAttribute] public int holdWeapon = 1;
    [XmlAttribute] public float scale;
    [XmlAttribute] public float sequenceSpeed;
    [XmlAttribute] public float knockBackDistance;
    [XmlAttribute] public int ignoreCollisionGroups;
    [XmlAttribute] public int noFly;
    [XmlAttribute] public int superArmor;
    [XmlAttribute] public int superArmorApplyFieldType;
    [XmlAttribute] public int skillUseDisable;
    [XmlAttribute] public int useFixedZRotation;
    [XmlAttribute] public float fixedZRotation;
    [M2dArray] public int[] skillUseDisableIDs = Array.Empty<int>();

    // Ignored by client.
    [XmlAttribute] public int confusion;
    [XmlAttribute] public int chaosMode;
    [XmlAttribute] public string materialEffect = string.Empty;
}