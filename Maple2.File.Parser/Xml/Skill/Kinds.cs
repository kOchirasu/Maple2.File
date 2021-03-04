using System.ComponentModel;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill {
    public class Kinds {
        [XmlAttribute] public int type;
        [XmlAttribute] public int subType;
        [XmlAttribute] public int rangeType;
        [XmlAttribute, DefaultValue(0)] public int groupType;
        [XmlAttribute] public int jump;
        [XmlAttribute] public string state; // ??
        [XmlAttribute("continue")] public int continueSkill;
        [XmlAttribute] public int spRecoverySkill;
        [XmlAttribute] public int element;
        [XmlAttribute] public int motionType;
        [XmlAttribute] public string emotion;
        [XmlAttribute] public float offsetNameTag;
        [XmlAttribute] public float offsetHPBar;
        [XmlAttribute] public int immediateActive;
        [XmlAttribute] public int weaponDependency;
        [XmlAttribute] public int unrideOnUse;
        [XmlAttribute] public int releaseObjectWeapon = 1;
        [XmlAttribute] public int releaseStunState;
        [XmlAttribute] public int disableWater;
        [XmlAttribute] public bool holdAttack;
        [XmlIgnore] public int[] groupIDs; // csv

        /* Custom Attribute Serializers */
        [XmlAttribute("groupIDs")]
        public string _groupIDs {
            get => Serialize.IntCsv(groupIDs);
            set => groupIDs = Deserialize.IntCsv(value);
        }

        // Ignored by client.
        [XmlAttribute] public int emotionNameTagOffset;
        [XmlAttribute] public string changeSkillCheckEffectID; // int[]
        [XmlAttribute] public string changeSkillCheckEffectLevel; // int[]
        [XmlAttribute] public string changeSkillID; // int[]
        [XmlAttribute] public int emotionType;
        [XmlAttribute] public int unrideOnHit;
    }
}