using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Skill.Property {
    public class ArrowProperty {
        [XmlAttribute] public int overlap;
        [XmlAttribute] public int explosion;
        [XmlAttribute] public int rayPhysxTest;
        [XmlAttribute] public int nonTarget;
        [XmlAttribute] public int bounceType;
        [XmlAttribute] public int bounceCount;
        [XmlAttribute] public float bounceRadius;
        [XmlAttribute] public int bounceOverlap = 1;
        [XmlIgnore] public Vector3 collision;
        [XmlIgnore] public Vector3 collisionAdd;
        [XmlAttribute] public int rayType;
        [XmlAttribute] public string effect = string.Empty;
        [XmlAttribute] public string effectRemain = string.Empty;
        [XmlAttribute] public string effectRay = string.Empty;
        [XmlAttribute] public string effectDestroy = string.Empty;
        [XmlAttribute] public string targetKeepEffect = string.Empty;
        [XmlAttribute] public string effectInvoke = string.Empty;

        /* Custom Attribute Serializers */
        [XmlAttribute("collision")]
        public string _collision {
            get => Serialize.Vector3(collision);
            set => collision = Deserialize.Vector3(value);
        }

        [XmlAttribute("collisionAdd")]
        public string _collisionAdd {
            get => Serialize.Vector3(collisionAdd);
            set => collisionAdd = Deserialize.Vector3(value);
        }
    }
}