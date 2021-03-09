using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class NodeCollisions {
        [XmlElement] public List<Collision> collision;

        [XmlType(Namespace="NodeCollisions")]
        public class Collision {
            [XmlAttribute] public string targetNode = string.Empty;
            [XmlIgnore] public Vector3 volume;
            [XmlIgnore] public Vector3 offset;

            /* Custom Attribute Serializers */
            [XmlAttribute("volume")]
            public string _volume {
                get => Serialize.Vector3(volume);
                set => volume = Deserialize.Vector3(value);
            }

            [XmlAttribute("offset")]
            public string _offset {
                get => Serialize.Vector3(offset);
                set => offset = Deserialize.Vector3(value);
            }
        }
    }

    public class NodeServerCollisions {
        [XmlElement] public List<Collision> collision;

        [XmlType(Namespace="NodeServerCollisions")]
        public class Collision {
            [XmlIgnore] public Vector3 volume;
            [XmlIgnore] public Vector3 offset;

            /* Custom Attribute Serializers */
            [XmlAttribute("volume")]
            public string _volume {
                get => Serialize.Vector3(volume);
                set => volume = Deserialize.Vector3(value);
            }

            [XmlAttribute("offset")]
            public string _offset {
                get => Serialize.Vector3(offset);
                set => offset = Deserialize.Vector3(value);
            }
        }
    }
}