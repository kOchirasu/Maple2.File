using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/vipgoodstable.xml
[XmlRoot("ms2")]
public class PremiumClubPackageRoot {
    [XmlElement] public List<PremiumClubPackage> goods;
}

public partial class PremiumClubPackage : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public bool disable;
    [XmlAttribute] public string salesStartDate;
    [XmlAttribute] public string salesEndDate;
    [XmlAttribute] public int vipPeriod;
    [XmlAttribute] public int price;
    [M2dEnum] public PremiumClubPriceType priceType = PremiumClubPriceType.BlueMeret;
    [M2dArray] public int[] bonusItemID = Array.Empty<int>();
    [M2dArray] public int[] bonusItemRank = Array.Empty<int>();
    [M2dArray] public int[] bonusItemCount = Array.Empty<int>();
    [M2dArray] public int[] bonusItemPeriod = Array.Empty<int>();
}
