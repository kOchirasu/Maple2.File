using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Map {
    public class Survival {
        [XmlAttribute] public short defaultMark;
        [XmlAttribute] public int defaultNameTag;

        // Ignored by client.
        [XmlAttribute] public int userDrop;
        [XmlAttribute] public int userAdditionalDrop;
        [XmlAttribute] public int userDropOwnership;
        [XmlAttribute] public int plusInven;
        [XmlAttribute] public int plusInven_Basic;
        [XmlAttribute] public int plusInven_Zero;
        [XmlIgnore] public int[] enteranceBuffIDs = Empty<int>();
        [XmlIgnore] public int[] enteranceBuffLevels = Empty<int>();
        [XmlAttribute] public bool ExtrafallDamage;

        /* Custom Attribute Serializers */
        [XmlAttribute("enteranceBuffIDs")]
        public string _enteranceBuffIDs {
            get => Serialize.IntCsv(enteranceBuffIDs);
            set => enteranceBuffIDs = Deserialize.IntCsv(value);
        }

        [XmlAttribute("enteranceBuffLevels")]
        public string _enteranceBuffLevels {
            get => Serialize.IntCsv(enteranceBuffLevels);
            set => enteranceBuffLevels = Deserialize.IntCsv(value);
        }
    }
}