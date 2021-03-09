using System;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class Skill {
        [XmlIgnore] public int[] ids = Array.Empty<int>();
        [XmlIgnore] public int[] levels = Array.Empty<int>();
        [XmlIgnore] public int[] priorities = Array.Empty<int>();
        [XmlIgnore] public int[] probs = Array.Empty<int>();
        [XmlAttribute] public int coolDown;

        /* Custom Attribute Serializers */
        [XmlAttribute("ids")]
        public string _ids {
            get => Serialize.IntCsv(ids);
            set => ids = Deserialize.IntCsv(value);
        }

        [XmlAttribute("levels")]
        public string _levels {
            get => Serialize.IntCsv(levels);
            set => levels = Deserialize.IntCsv(value);
        }

        [XmlAttribute("priorities")]
        public string _priorities {
            get => Serialize.IntCsv(priorities);
            set => priorities = Deserialize.IntCsv(value);
        }

        [XmlAttribute("probs")]
        public string _probs {
            get => Serialize.IntCsv(probs);
            set => probs = Deserialize.IntCsv(value);
        }
    }
}