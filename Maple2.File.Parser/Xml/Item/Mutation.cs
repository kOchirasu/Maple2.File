using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Item {
    public class Mutation {
        [XmlAttribute] public int interval = 2;
        [XmlIgnore] public string[] assets = Empty<string>();
        [XmlIgnore] public int[] skills = Empty<int>();
        [XmlAttribute] public string changeeffect = string.Empty;

        /* Custom Attribute Serializers */
        [XmlAttribute("assets")]
        public string _assets {
            get => Serialize.StringCsv(assets);
            set => assets = Deserialize.StringCsv(value);
        }

        [XmlAttribute("skills")]
        public string _skills {
            get => Serialize.IntCsv(skills);
            set => skills = Deserialize.IntCsv(value);
        }
    }
}