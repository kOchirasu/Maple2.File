using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class InvokeEffectProperty {
        [XmlAttribute] public int skillID;
        [XmlAttribute] public int skillGroupID;
        [XmlAttribute] public int effectID;
        [XmlAttribute] public int effectGroupID;
        [XmlIgnore] public int[] types;
        [XmlIgnore] public float[] values;
        [XmlIgnore] public float[] rates;

        /* Custom Attribute Serializers */
        [XmlAttribute("types")]
        public string _types {
            get => Serialize.IntCsv(types);
            set => types = Deserialize.IntCsv(value);
        }

        [XmlAttribute("values")]
        public string _values {
            get => Serialize.FloatCsv(values);
            set => values = Deserialize.FloatCsv(value);
        }

        [XmlAttribute("rates")]
        public string _rates {
            get => Serialize.FloatCsv(rates);
            set => rates = Deserialize.FloatCsv(value);
        }
    }
}