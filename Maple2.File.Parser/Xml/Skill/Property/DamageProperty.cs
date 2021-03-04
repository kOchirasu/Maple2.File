using System.ComponentModel;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill.Property {
    public class DamageProperty {
        [XmlAttribute] public int count = 1;
        [XmlAttribute] public int hand;
        [XmlAttribute] public float rate;
        [XmlAttribute] public float hitSpeedRate = 1.0f;
        [XmlAttribute] public float hitPauseTime;
        [XmlAttribute] public float damagedVibrateRatio = 1.0f;
        [XmlAttribute] public long value;
        [XmlAttribute] public int isConstDamageValue;
        [XmlAttribute] public float damageByTargetMaxHP;
        [XmlAttribute] public long constDamageByTargetHP;
        [XmlAttribute] public long constDamageByTargetSP;
        [XmlAttribute] public string effectHit;
        [XmlAttribute] public string effectRemain;
        [XmlAttribute] public bool IgnoreOptimalHideDamageHitEffect;
        [XmlAttribute] public bool IgnoreOptimalHideDamageRemainEffect;
        [XmlAttribute, DefaultValue(0)] public int push;
        [XmlAttribute] public float pushdistance;
        [XmlAttribute] public float pushduration;
        [XmlAttribute] public float pushprob = 1.0f;
        [XmlAttribute, DefaultValue(0)] public int pushEaseType; // if n < 0 || n > 2, set to 0
        [XmlAttribute, DefaultValue(0)] public int pushApplyField;
        [XmlAttribute] public int pushDown;
        [XmlAttribute] public int pushFall;
        [XmlAttribute] public int pushPriority;
        [XmlAttribute] public int pushPriorityHitImmune;
        [XmlAttribute] public string pushAnimation;
        [XmlAttribute] public float pushUpDistance;
        [XmlAttribute] public int attackMaterial;
        [XmlAttribute] public int jumpHitIgnore;
        [XmlAttribute] public int superArmorBreak;
        [XmlAttribute] public int invokeEffectDisable;
        [XmlAttribute] public int damageEventDisable;
        [XmlAttribute] public long damageRefBap;
        [XmlAttribute] public long damageRefWap;
        [XmlAttribute] public long damageRefTap;
    }
}