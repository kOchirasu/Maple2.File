using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill;

public class AutoTargeting {
    [XmlAttribute] public float autoTargetingMaxDegree = 210.0f;
    [XmlAttribute] public float autoTargetingMaxDistance;
    [XmlAttribute] public float autoTargetingMaxHeight;
    [XmlAttribute] public bool autoTargetUseMove;
}
