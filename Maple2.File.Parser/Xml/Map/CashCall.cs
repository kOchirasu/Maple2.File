using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map {
    public class CashCall {
        [XmlAttribute] public int cashTaxiNotDeparture;
        [XmlAttribute] public int cashTaxiNotDestination;
        [XmlAttribute] public int cashCallMedicProhibit;
        [XmlAttribute] public int cashCallMarketProhibit;
        [XmlAttribute] public int RecallOtherUserProhibit;
    }
}