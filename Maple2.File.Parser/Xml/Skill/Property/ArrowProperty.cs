using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill.Property;

public partial class ArrowProperty {
    [XmlAttribute] public bool overlap;
    [XmlAttribute] public bool explosion;
    [XmlAttribute] public bool rayPhysxTest;
    [XmlAttribute] public int nonTarget; // 0,1,2
    [XmlAttribute] public int bounceType; // 0,1,2,3,4,5
    [XmlAttribute] public int bounceCount; // 0,1,2,3,4,5,7,8,10,12,13,20,30,50,64,70,90,99,160,200
    [XmlAttribute] public float bounceRadius;
    [XmlAttribute] public bool bounceOverlap = true;
    [M2dVector3] public Vector3 collision;
    [M2dVector3] public Vector3 collisionAdd;
    [XmlAttribute] public int rayType; // 0,1,2
    [XmlAttribute] public string effect = string.Empty;
    [XmlAttribute] public string effectRemain = string.Empty;
    [XmlAttribute] public string effectRay = string.Empty;
    [XmlAttribute] public string effectDestroy = string.Empty;
    [XmlAttribute] public string targetKeepEffect = string.Empty;
    [XmlAttribute] public string effectInvoke = string.Empty;
}
