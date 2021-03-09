using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class Corpse {
        [XmlAttribute] public float width;
        [XmlAttribute] public float height;
        [XmlAttribute] public float depth;
        [XmlAttribute] public float added;
        [XmlAttribute] public float offsetNametag;
        [XmlAttribute] public int hitAble;
        [XmlIgnore] public Vector3 rotation;
        [XmlAttribute] public string corpseEffect = string.Empty;

        /* Custom Attribute Serializers */
        [XmlAttribute("rotation")]
        public string _rotation {
            get => Serialize.Vector3(rotation);
            set => rotation = Deserialize.Vector3(value);
        }
    }
}