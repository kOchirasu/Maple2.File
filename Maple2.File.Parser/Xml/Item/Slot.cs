using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Item {
    public class Slots {
        [XmlElement] public List<Slot> slot;
    }

    public class Slot {
        [XmlAttribute] public string name = string.Empty;

        [XmlElement] public List<Asset> asset;
        [XmlElement] public List<Scale> scale;
        [XmlElement] public Decal decal;

        public class Asset {
            [XmlAttribute] public string name = string.Empty;
            [XmlAttribute] public string selfnode = string.Empty;
            [XmlAttribute] public string targetnode = string.Empty;
            [XmlAttribute] public string attachnode = string.Empty;
            [XmlAttribute] public int pony;
            [XmlAttribute] public int zalign;
            [XmlAttribute] public int replace;
            [XmlAttribute] public int earfold;
            [XmlAttribute] public int ani;
            [XmlAttribute] public int emotionhide;
            [XmlAttribute] public int gender;
            [XmlAttribute] public float capscale;
            [XmlAttribute] public float mantlescale;
            [XmlAttribute] public int weapon;
            [XmlAttribute] public int placeable;

            [XmlElement] public List<Custom> custom;
            [XmlElement] public List<UserRotation> userrotation;
            [XmlElement] public List<JointAngle> jointangle;
            [XmlElement] public List<Dummy> dummy;
            [XmlElement] public PhysX physx;
        }

        public class Scale {
            [XmlIgnore] public float[] values = Empty<float>();
            [XmlAttribute] public float min;
            [XmlAttribute] public float max;
            [XmlAttribute] public int reverse;

            /* Custom Attribute Serializers */
            [XmlAttribute("value")]
            public string _value {
                get => Serialize.FloatCsv(values);
                set => values = Deserialize.FloatCsv(value);
            }
        }

        public class Decal {
            [XmlAttribute] public string texture = string.Empty;
            [XmlAttribute] public string controlTexture = string.Empty;

            [XmlElement] public List<Custom> custom;
        }

        public class Custom {
            [XmlAttribute] public string icon = string.Empty;
            [XmlAttribute] public string position = string.Empty;
            [XmlAttribute] public string rotation = string.Empty;
        }

        public class UserRotation {
            [XmlAttribute] public string axis = string.Empty;
            [XmlAttribute] public float min;
            [XmlAttribute] public float max;
            [XmlIgnore] public float[] @default = Empty<float>();

            /* Custom Attribute Serializers */
            [XmlAttribute("default")]
            public string _default {
                get => Serialize.FloatCsv(@default);
                set => @default = Deserialize.FloatCsv(value);
            }
        }

        public class JointAngle {
            [XmlAttribute] public string name = string.Empty;
            [XmlAttribute] public float soft;
            [XmlAttribute] public float posz;
            [XmlAttribute] public float zero;
            [XmlAttribute] public float negz;
        }

        public class Dummy {
            [XmlAttribute] public int gender;
            [XmlAttribute] public string sequence = string.Empty;
            [XmlAttribute] public string targetnode = string.Empty;
            [XmlAttribute] public bool worldmode;
            [XmlAttribute] public bool worldlerp;
            [XmlAttribute] public float step;
            [XmlIgnore] public Vector3 rotation;
            [XmlIgnore] public Vector3 translation;

            /* Custom Attribute Serializers */
            [XmlAttribute("rotation")]
            public string _rotation {
                get => Serialize.Vector3(rotation);
                set => rotation = Deserialize.Vector3(value);
            }

            [XmlAttribute("translation")]
            public string _translation {
                get => Serialize.Vector3(translation);
                set => translation = Deserialize.Vector3(value);
            }
        }

        public class PhysX {
            [XmlIgnore] public string[] action = Empty<string>();

            /* Custom Attribute Serializers */
            [XmlAttribute("action")]
            public string _action {
                get => Serialize.StringCsv(action);
                set => action = Deserialize.StringCsv(value);
            }
        }
    }
}