using System;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class Dead {
        [XmlAttribute] public float time = 2.0f;
        [XmlIgnore] public string[] defaultaction = Array.Empty<string>();
        [XmlIgnore] public string[] upaction = Array.Empty<string>();
        [XmlAttribute] public int revival;
        [XmlAttribute] public int count = 1;
        [XmlAttribute] public float lifeTime;
        [XmlAttribute] public int extendRoomTime;

        /* Custom Attribute Serializers */
        [XmlAttribute("defaultaction")]
        public string _defaultaction {
            get => Serialize.StringCsv(defaultaction);
            set => defaultaction = Deserialize.StringCsv(value);
        }

        [XmlAttribute("upaction")]
        public string _upaction {
            get => Serialize.StringCsv(upaction);
            set => upaction = Deserialize.StringCsv(value);
        }

        // Ignored by client.
        [XmlAttribute] public int slowLastHit;
    }
}