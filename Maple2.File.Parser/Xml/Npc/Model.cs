using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class Model {
        [XmlAttribute] public string kfm = string.Empty;
        [XmlAttribute] public float scale = 1.0f;
        [XmlAttribute] public float anispeed = 1.0f;
        [XmlAttribute] public bool anispeedfix;
        [XmlAttribute] public int spawnAlphaAnimation = 1;
        [XmlIgnore] public Vector3 offset;

        /* Custom Attribute Serializers */
        [XmlAttribute("offset")]
        public string _offset {
            get => Serialize.Vector3(offset);
            set => offset = Deserialize.Vector3(value);
        }
    }
}