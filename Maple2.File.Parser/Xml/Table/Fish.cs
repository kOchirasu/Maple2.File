using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/fish.xml
[XmlRoot("ms2")]
public partial class FishRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<Fish> _fish;
}

public partial class Fish : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public bool fishingBook;
    [XmlAttribute] public string habitat;
    [XmlAttribute] public int fishMastery;
    [XmlAttribute] public int rank;
    [XmlAttribute] public string smallSize;
    [XmlAttribute] public string bigSize;
    [XmlAttribute] public bool ignoreSpotMastery;
}
