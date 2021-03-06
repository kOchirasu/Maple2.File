using System.ComponentModel;
using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Skill.Property {
    public class ArrowProperty {
        [XmlAttribute] public int overlap;
        [XmlAttribute] public int explosion;
        [XmlAttribute] public int rayPhysxTest;
        [XmlAttribute, DefaultValue(0)] public int nonTarget;
        [XmlAttribute] public int bounceType;
        [XmlAttribute] public int bounceCount;
        [XmlAttribute] public float bounceRadius;
        [XmlAttribute] public int bounceOverlap = 1;
        [XmlIgnore] public Vector3 collision;
        [XmlIgnore] public Vector3 collisionAdd;
        [XmlAttribute] public int rayType;
        [XmlAttribute] public string effect;
        [XmlAttribute] public string effectRemain;
        [XmlAttribute] public string effectRay;
        [XmlAttribute] public string effectDestroy;
        [XmlAttribute] public string targetKeepEffect;
        [XmlAttribute] public string effectInvoke;

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