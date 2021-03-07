using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Item {
    public class Life {
        [XmlAttribute] public int usePeriod;
        [XmlIgnore] public int[] expirationPeriod = Empty<int>();
        [XmlAttribute] public int expirationType;
        [XmlAttribute] public int numberOfWeeksMonths;

        /* Custom Attribute Serializers */
        [XmlAttribute("expirationPeriod")]
        public string _expirationPeriod {
            get => Serialize.IntCsv(expirationPeriod, '-');
            set => expirationPeriod = Deserialize.IntCsv(value, '-');
        }
    }
}