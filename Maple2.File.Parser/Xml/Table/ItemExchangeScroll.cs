using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itemexchangescrolltable.xml
[XmlRoot("ms2")]
public class ItemExchangeScrollRoot {
    [XmlElement] public List<ItemExchangeScroll> scroll;
}

public partial class ItemExchangeScroll : IFeatureLocale {
    [XmlAttribute] public int id;
    [M2dEnum] public ItemExchangeScrollType type;
    [XmlElement] public Recipe recipe;
    [XmlElement] public RequiredEquip requiredEquip;
    [XmlElement] public Exchange exchange;
    [XmlElement] public Require require;
    
    public class Recipe {
        [XmlAttribute] public int id;
        [XmlAttribute] public int rank;
        [XmlAttribute] public int count;
    }

    public class RequiredEquip {
        [XmlAttribute] public int id;
        [XmlAttribute] public int rank;
        [XmlAttribute] public int count;
    }

    public class Exchange {
        [XmlAttribute] public int id;
        [XmlAttribute] public int rank;
        [XmlAttribute] public int count;
    }

    public class Require {
        [XmlAttribute] public long meso;
    }
}
