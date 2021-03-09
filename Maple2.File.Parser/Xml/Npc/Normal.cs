using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class Normal {
        [XmlIgnore] public string[] action = {"Idle_A"};
        [XmlIgnore] public int[] prob = {10000};
        [XmlAttribute] public int movearea;
        [XmlAttribute] public string maidExpired = string.Empty;

        /* Custom Attribute Serializers */
        [XmlAttribute("action")]
        public string _action {
            get => Serialize.StringCsv(action);
            set => action = Deserialize.StringCsv(value);
        }

        [XmlAttribute("prob")]
        public string _prob {
            get => Serialize.IntCsv(prob);
            set => prob = Deserialize.IntCsv(value);
        }
    }
}