using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill.Property {
    public partial class ArrowProperty {
        [XmlAttribute] public int overlap;
        [XmlAttribute] public int explosion;
        [XmlAttribute] public int rayPhysxTest;
        [XmlAttribute] public int nonTarget;
        [XmlAttribute] public int bounceType;
        [XmlAttribute] public int bounceCount;
        [XmlAttribute] public float bounceRadius;
        [XmlAttribute] public int bounceOverlap = 1;
        [M2dVector3] public Vector3 collision;
        [M2dVector3] public Vector3 collisionAdd;
        [XmlAttribute] public int rayType;
        [XmlAttribute] public string effect = string.Empty;
        [XmlAttribute] public string effectRemain = string.Empty;
        [XmlAttribute] public string effectRay = string.Empty;
        [XmlAttribute] public string effectDestroy = string.Empty;
        [XmlAttribute] public string targetKeepEffect = string.Empty;
        [XmlAttribute] public string effectInvoke = string.Empty;
    }
}
