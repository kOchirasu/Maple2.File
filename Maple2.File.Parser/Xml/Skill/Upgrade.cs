using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Skill {
    public class Upgrade {
        [XmlAttribute] public short level;
        [XmlIgnore] public int[] skillIDs = Empty<int>();
        [XmlIgnore] public int[] skillLevels = Empty<int>();
        [XmlIgnore] public int[] questIDs = Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("skillIDs")]
        public string _skillIDs {
            get => Serialize.IntCsv(skillIDs);
            set => skillIDs = Deserialize.IntCsv(value);
        }

        [XmlAttribute("skillLevels")]
        public string _skillLevels {
            get => Serialize.IntCsv(skillLevels);
            set => skillLevels = Deserialize.IntCsv(value);
        }

        [XmlAttribute("questIDs")]
        public string _questIDs {
            get => Serialize.IntCsv(questIDs);
            set => questIDs = Deserialize.IntCsv(value);
        }

        // Ignored by client.
        [XmlAttribute] public int money;
    }
}