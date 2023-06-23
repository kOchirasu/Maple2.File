using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/meratmarketcategory.xml
[XmlRoot("ms2")]
public partial class MeretMarketCategoryRoot {
    [XmlElement] public List<MeretMarketCategory> category;
    [XmlElement] public List<MeretMarketEnvironment> environment;
}

public partial class MeretMarketCategory {
    [XmlAttribute] public int id;
    [XmlAttribute] public string tabType;
    [XmlElement] public List<Tab> tab;
    
    public partial class Tab {
        [XmlAttribute] public string name;
        [XmlAttribute] public int id;
        [XmlAttribute] public string symbol;
        [XmlAttribute] public byte priority;
        [XmlAttribute] public byte @static;
        [XmlAttribute] public bool sortGender;
        [XmlAttribute] public bool sortJob;
        [XmlAttribute] public bool alwaysOpen;
        [XmlElement] public List<Tab> tab;
    }
}

public partial class MeretMarketEnvironment : IFeatureLocale {
    [XmlElement] public List<MeretMarketCategory> category;
}