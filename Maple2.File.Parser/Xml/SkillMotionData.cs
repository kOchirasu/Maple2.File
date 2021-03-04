using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml {
    public class SkillMotionData {
        [XmlElement] public List<SkillMotionProperty> motionProperty;
        [XmlElement] public List<SkillAttackData> attack;
    }

    public class SkillMotionProperty {
        [XmlAttribute] public string sequenceName;
        [XmlAttribute] public string motionEffect;
        [XmlAttribute] public string loopEffect;
        [XmlAttribute] public string endEffect;
        [XmlAttribute] public string splashInvokeEffect;
        [XmlAttribute] public string splashEndEffect;
        [XmlIgnore] public string[] strTagEffects; // csv
        [XmlAttribute] public string selfInputCombo;
        [XmlAttribute] public string weaponSequenceName;
        [XmlAttribute] public string loopKeepEffect;
        [XmlAttribute] public string loopEndEffect;
        [XmlAttribute] public string splashDurationCastEffect;
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
        [XmlAttribute, DefaultValue(0)] public int moveEaseType;
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
}