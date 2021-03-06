﻿using System.ComponentModel;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class MotionProperty {
        [XmlAttribute] public string sequenceName;
        [XmlAttribute] public string startEffect;
        [XmlAttribute] public string keepEffect;
        [XmlAttribute] public string stopEffect;
        [XmlAttribute] public string invokeEffect;
        [XmlAttribute] public bool IgnoreOptimalHideStartEffect;
        [XmlAttribute] public bool IgnoreOptimalHideKeepEffect;
        [XmlAttribute] public bool IgnoreOptimalHideStopEffect;
        [XmlAttribute] public bool IgnoreOptimalHideInvokeEffect;
        [XmlIgnore] public int[] disableEffectStates; // csv
        [XmlAttribute] public int hide;
        [XmlIgnore] public int[] clearCondition; // csv
        [XmlAttribute] public float alphaBlending = 1.0f;
        [XmlAttribute] public int stun;
        [XmlAttribute] public string stunAnimation;
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
        [XmlAttribute, DefaultValue(0)] public int superArmorApplyFieldType;
        [XmlAttribute] public int skillUseDisable;
        [XmlAttribute] public int useFixedZRotation;
        [XmlAttribute] public float fixedZRotation;
        [XmlIgnore] public int[] skillUseDisableIDs; // csv

        /* Custom Attribute Serializers */
        [XmlAttribute("disableEffectStates")]
        public string _disableEffectStates {
            get => Serialize.IntCsv(disableEffectStates);
            set => disableEffectStates = Deserialize.IntCsv(value);
        }

        [XmlAttribute("clearCondition")]
        public string _clearCondition {
            get => Serialize.IntCsv(clearCondition);
            set => clearCondition = Deserialize.IntCsv(value);
        }

        [XmlAttribute("skillUseDisableIDs")]
        public string _skillUseDisableIDs {
            get => Serialize.IntCsv(skillUseDisableIDs);
            set => skillUseDisableIDs = Deserialize.IntCsv(value);
        }

        // Ignored by client.
        [XmlAttribute] public int confusion;
        [XmlAttribute] public int chaosMode;
        [XmlAttribute] public string materialEffect;
    }
}