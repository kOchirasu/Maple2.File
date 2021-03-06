using System.ComponentModel;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Skill {
    // Typed
    public class TriggerSkill {
        [XmlAttribute] public int splash;
        [XmlAttribute] public int randomCast;
        [XmlIgnore] public int[] level; // csv
        [XmlIgnore] public int[] skillID; // csv
        [XmlIgnore] public int[] linkSkillID; // csv
        [XmlAttribute] public int overlapCount = 1;
        [XmlAttribute] public int skillTarget;
        [XmlAttribute, DefaultValue(1)] public int skillOwner = 1; // if 0 then 1?
        [XmlAttribute] public uint delay;
        [XmlAttribute] public int removeDelay;
        [XmlAttribute] public int interval;
        [XmlAttribute] public int immediateActive;
        [XmlAttribute] public int fireCount = 1;
        [XmlAttribute] public int nonTargetActive;
        [XmlAttribute] public int useDirection;
        [XmlAttribute] public int onlySensingActive;
        [XmlAttribute] public int dependOnCasterState;
        [XmlAttribute] public int activeByIntervalTick;
        [XmlAttribute] public int dependOnDamageCount;
        [XmlAttribute] public int independent;
        [XmlAttribute, DefaultValue(0)] public int chain;
        [XmlAttribute, DefaultValue(150.0f)] public float chainDistance = 150.0f; // default to 150.0 if not float

        [XmlElement] public BeginCondition beginCondition;

        /* Custom Attribute Serializers */
        [XmlAttribute("level")]
        public string _level {
            get => Serialize.IntCsv(level);
            set => level = Deserialize.IntCsv(value);
        }

        [XmlAttribute("skillID")]
        public string _skillID {
            get => Serialize.IntCsv(skillID);
            set => skillID = Deserialize.IntCsv(value);
        }

        [XmlAttribute("linkSkillID")]
        public string _linkSkillID {
            get => Serialize.IntCsv(linkSkillID);
            set => linkSkillID = Deserialize.IntCsv(value);
        }
    }
}