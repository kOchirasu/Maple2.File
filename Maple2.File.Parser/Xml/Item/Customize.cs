using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Item {
    public class Customize {
        [XmlAttribute] public int colorPalette;
        [XmlAttribute] public int color;
        [XmlAttribute] public int ch0;
        [XmlAttribute] public int ch1;
        [XmlAttribute] public int ch2;
        [XmlAttribute] public int colordetail;
        [XmlAttribute] public int defaultColorIndex = -1;

        [XmlElement] public Hair HR;
        [XmlElement] public FaceDecal FD;
        [XmlElement] public Cap CP;

        public class Hair {
            [XmlAttribute] public int scale;
            [XmlAttribute] public int pony;
        }

        public class FaceDecal {
            [XmlAttribute] public int translation;
            [XmlAttribute] public int rotation;
            [XmlAttribute] public int scale;
        }

        public class Cap {
            [XmlAttribute] public int xrotation;
            [XmlAttribute] public int yrotation;
            [XmlAttribute] public int zrotation;
            [XmlAttribute] public int scale;
            [XmlAttribute] public int attach;

            [XmlElement] public List<Transform> transform;
        }

        public class Transform {
            [XmlIgnore] public Vector3 position;
            [XmlIgnore] public Vector3 rotation;
            [XmlAttribute] public float scale;

            /* Custom Attribute Serializers */
            [XmlAttribute("position")]
            public string _position {
                get => Serialize.Vector3(position);
                set => position = Deserialize.Vector3(value);
            }

            [XmlAttribute("rotation")]
            public string _rotation {
                get => Serialize.Vector3(rotation);
                set => rotation = Deserialize.Vector3(value);
            }
        }
    }


}