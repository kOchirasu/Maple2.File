using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/vipbenefiteffecttable.xml
[XmlRoot("ms2")]
public class PremiumClubEffectRoot {
    [XmlElement] public List<PremiumClubEffect> benefit;
}

public partial class PremiumClubEffect : IFeatureLocale {
    [XmlAttribute] public int effectID;
    [XmlAttribute] public bool effectLevel;
}
