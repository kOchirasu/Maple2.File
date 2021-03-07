using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class ImmuneEffectProperty {
        [XmlIgnore] public int[] immuneEffectCodes = Empty<int>();
        [XmlIgnore] public int[] immuneBuffCategories = Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("immuneEffectCodes")]
        public string _immuneEffectCodes {
            get => Serialize.IntCsv(immuneEffectCodes);
            set => immuneEffectCodes = Deserialize.IntCsv(value);
        }

        [XmlAttribute("immuneBuffCategories")]
        public string _immuneBuffCategories {
            get => Serialize.IntCsv(immuneBuffCategories);
            set => immuneBuffCategories = Deserialize.IntCsv(value);
        }
    }
}