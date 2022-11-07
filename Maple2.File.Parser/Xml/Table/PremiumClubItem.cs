using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/vipbenefititemtable.xml
[XmlRoot("ms2")]
public class PremiumClubItemRoot {
    [XmlElement] public List<PremiumClubItem> benefit;
}

public partial class PremiumClubItem : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int itemID;
    [XmlAttribute] public int itemCount;
    [XmlAttribute] public int itemRank;
    [XmlAttribute] public int itemPeriod;
}
