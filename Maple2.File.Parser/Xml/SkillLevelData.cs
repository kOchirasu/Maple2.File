using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Skill;
using Maple2.File.Parser.Xml.Skill.Property;

namespace Maple2.File.Parser.Xml {
    public class SkillLevelData {
        [XmlAttribute] public string feature;
        [XmlAttribute] public int value;

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
}