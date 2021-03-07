using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class ModifyEffectDurationProperty {
        [XmlIgnore] public int[] effectCodes = Empty<int>();
        [XmlIgnore] public float[] durationFactors = Empty<float>();
        [XmlIgnore] public float[] durationValues = Empty<float>();

        /* Custom Attribute Serializers */
        [XmlAttribute("effectCodes")]
        public string _effectCodes {
            get => Serialize.IntCsv(effectCodes);
            set => effectCodes = Deserialize.IntCsv(value);
        }

        [XmlAttribute("durationFactors")]
        public string _durationFactors {
            get => Serialize.FloatCsv(durationFactors);
            set => durationFactors = Deserialize.FloatCsv(value);
        }

        [XmlAttribute("durationValues")]
        public string _durationValues {
            get => Serialize.FloatCsv(durationValues);
            set => durationValues = Deserialize.FloatCsv(value);
        }
    }
}