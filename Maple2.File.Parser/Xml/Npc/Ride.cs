using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class Ride {
        [XmlAttribute] public float rideScale;
        [XmlAttribute] public string rideBone = string.Empty;
        [XmlAttribute] public string rideAnimation = string.Empty;
        [XmlIgnore] public Vector3 rideTranslation;
        [XmlIgnore] public Vector3 rideRotation;
        [XmlAttribute] public float rideSpeed;
        [XmlAttribute] public string rideSkill = string.Empty;
        [XmlAttribute] public int rideSkill2;

        /* Custom Attribute Serializers */
        [XmlAttribute("rideTranslation")]
        public string _rideTranslation {
            get => Serialize.Vector3(rideTranslation);
            set => rideTranslation = Deserialize.Vector3(value);
        }

        [XmlAttribute("rideRotation")]
        public string _rideRotation {
            get => Serialize.Vector3(rideRotation);
            set => rideRotation = Deserialize.Vector3(value);
        }
    }
}