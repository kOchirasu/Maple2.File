using System;
using System.ComponentModel;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Skill {
    public partial class TriggerSkill {
        [XmlAttribute] public int splash;
        [XmlAttribute] public int randomCast;
        [M2dArray] public int[] level = Array.Empty<int>();
        [M2dArray] public int[] skillID = Array.Empty<int>();
        [M2dArray] public int[] linkSkillID = Array.Empty<int>();
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
        [XmlAttribute] public int chain;
        [XmlAttribute, DefaultValue(150.0f)] public float chainDistance = 150.0f; // default to 150.0 if not float

        [XmlElement] public BeginCondition beginCondition;
    }
}