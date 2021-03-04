using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Xml.AdditionalEffect;
using Maple2.File.Parser.Xml.Skill;

namespace Maple2.File.Parser.Xml {
    public class AdditionalEffectData {
        [XmlAttribute] public string locale;
        [XmlAttribute] public string feature;

        [XmlElement] public BeginCondition beginCondition;
        [XmlElement] public BasicProperty BasicProperty;
        [XmlElement] public MotionProperty MotionProperty;
        [XmlElement] public CancelEffectProperty CancelEffectProperty;
        [XmlElement] public ImmuneEffectProperty ImmuneEffectProperty;
        [XmlElement] public ResetSkillCoolDownTimeProperty ResetSkillCoolDownTimeProperty;
        [XmlElement] public ModifyEffectDurationProperty ModifyEffectDurationProperty;
        [XmlElement] public ModifyOverlapCountProperty ModifyOverlapCountProperty;
        [XmlElement] public StatusProperty StatusProperty;
        [XmlElement] public FinalStatusProperty FinalStatusProperty;
        [XmlElement] public OffensiveProperty OffensiveProperty;
        [XmlElement] public DefensiveProperty DefensiveProperty;
        [XmlElement] public RecoveryProperty RecoveryProperty;
        [XmlElement] public ExpProperty ExpProperty;
        [XmlElement] public DotDamageProperty DotDamageProperty;
        [XmlElement] public DotBuffProperty DotBuffProperty;
        [XmlElement] public ConsumeProperty ConsumeProperty;
        [XmlElement] public ReflectProperty ReflectProperty;
        [XmlElement] public UIProperty UIProperty;
        [XmlElement] public ShieldProperty ShieldProperty;
        [XmlElement] public MesoGuardProperty MesoGuardProperty;
        [XmlElement] public InvokeEffectProperty InvokeEffectProperty;
        [XmlElement] public SpecialEffectProperty SpecialEffectProperty;
        [XmlElement] public RideeProperty RideeProperty;

        [XmlElement] public List<TriggerSkill> splashSkill;
        [XmlElement] public List<TriggerSkill> conditionSkill;
    }
}