using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml {
    public class SkillGlideData {
        [XmlAttribute] public float gravity;
        [XmlAttribute] public float heightLimit;
        [XmlAttribute] public float horizontalAccelerate;
        [XmlAttribute] public float horizontalVelocity;
        [XmlAttribute] public float verticalAccelerate;
        [XmlAttribute] public float verticalVelocity;
        [XmlAttribute] public float verticalVibrateAmplitude;
        [XmlAttribute] public float verticalVibrateFrequency;
        [XmlAttribute] public float glideVerticalAccelerateLimit;
        [XmlAttribute] public float glideHorizontalAccelerateLimit;
        [XmlAttribute] public bool bEffect;
        [XmlAttribute] public string effectRun;
        [XmlAttribute] public string effectIdle;
        [XmlAttribute] public string aniIdle;
        [XmlAttribute] public string aniLeft;
        [XmlAttribute] public string aniRight;
        [XmlAttribute] public string aniRun;
        [XmlAttribute] public bool onGroundDisable;
    }
}