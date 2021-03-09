using System;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class AdditionalEffect {
        [XmlIgnore] public int[] codes = Array.Empty<int>();
        [XmlIgnore] public int[] levels = Array.Empty<int>();
        [XmlIgnore] public string[] group = Array.Empty<string>();
        [XmlIgnore] public int[] rewardCodes = Array.Empty<int>();
        [XmlIgnore] public int[] rewardLevels = Array.Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("codes")]
        public string _codes {
            get => Serialize.IntCsv(codes);
            set => codes = Deserialize.IntCsv(value);
        }

        [XmlAttribute("levels")]
        public string _levels {
            get => Serialize.IntCsv(levels);
            set => levels = Deserialize.IntCsv(value);
        }

        [XmlAttribute("group")]
        public string _group {
            get => Serialize.StringCsv(group, ':');
            set => group = Deserialize.StringCsv(value, ':');
        }

        [XmlAttribute("rewardCodes")]
        public string _rewardCodes {
            get => Serialize.IntCsv(rewardCodes);
            set => rewardCodes = Deserialize.IntCsv(value);
        }

        [XmlAttribute("rewardLevels")]
        public string _rewardLevels {
            get => Serialize.IntCsv(rewardLevels);
            set => rewardLevels = Deserialize.IntCsv(value);
        }
    }
}