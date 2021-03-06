using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Item {
    public class Life {
        [XmlAttribute] public int usePeriod;
        [XmlIgnore] public int[] expirationPeriod;
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