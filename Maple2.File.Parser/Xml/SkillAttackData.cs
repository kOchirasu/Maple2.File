using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Skill;
using Maple2.File.Parser.Xml.Skill.Property;

namespace Maple2.File.Parser.Xml {
    public class SkillAttackData {
        [XmlAttribute] public string point;
        [XmlAttribute] public int pointGroupID;
        [XmlAttribute] public int targetCount;
        [XmlAttribute] public int magicPathID;
        [XmlAttribute] public int cubeMagicPathID;
        [XmlAttribute] public int direction = 3;
        [XmlAttribute] public int sequence;
        [XmlAttribute, DefaultValue(0)] public int attacktype;
        [XmlAttribute, DefaultValue(0)] public int attackMethodType;
        [XmlAttribute] public int hitImmuneBreak;
        [XmlAttribute] public float brokenForce;
        [XmlAttribute] public int brokenOffence;
        [XmlAttribute, DefaultValue(0)] public int unrideOnHit;
        [XmlAttribute] public int releaseObjectWeaponOnHit = 1;
        [XmlIgnore] public int[] compulsionType; // csv
        [XmlAttribute] public int grabTargetType;
        [XmlIgnore] public string[] grabNodeCategory; // csv

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
        [XmlAttribute] public string compulsionHit;
    }
}