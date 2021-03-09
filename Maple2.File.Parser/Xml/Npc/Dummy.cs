using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class EffectDummy {
        [XmlElement] public List<Dummy> dummy;
    }

    public class Dummy {
        [XmlAttribute] public string name = string.Empty;

        [XmlElement] public AttachInfo attachInfo;
        [XmlElement] public Transform transform;

        public class AttachInfo {
            [XmlAttribute] public string parentNode = string.Empty;
            [XmlAttribute] public bool applyWorldTransform;
            [XmlAttribute] public bool applyLocalScale;
        }

        public class Transform {
            [XmlIgnore] public Vector3 translate;
            [XmlIgnore] public Vector3 rotation;
            [XmlAttribute] public float scale;

            /* Custom Attribute Serializers */
            [XmlAttribute("translate")]
            public string _translate {
                get => Serialize.Vector3(translate);
                set => translate = Deserialize.Vector3(value);
            }

            [XmlAttribute("rotation")]
            public string _rotation {
                get => Serialize.Vector3(rotation);
                set => rotation = Deserialize.Vector3(value);
            }
        }
    }
}