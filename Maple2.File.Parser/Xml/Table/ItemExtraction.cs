using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/itemextraction.xml
[XmlRoot("ms2")]
public class ItemExtractionRoot {
    [XmlElement] public List<ItemExtraction> key;
}

public partial class ItemExtraction {
    [XmlAttribute] public int TargetItemID;
    [XmlAttribute] public int TryCount;
    [XmlAttribute] public int ScrollCount;
    [XmlAttribute] public int ResultItemID;
}
