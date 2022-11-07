using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itemexchangescrolltable.xml
[XmlRoot("ms2")]
public partial class ItemExchangeScrollRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<ItemExchangeScroll> _scroll;
}

public partial class ItemExchangeScroll : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int maxGrade;
    [XmlAttribute] public int tradableCountDeduction;
    
    [M2dEnum] public ItemExchangeScrollType type;
    [XmlElement] public Ingredient recipe;
    [XmlElement] public Ingredient requiredEquip;
    [XmlElement] public Ingredient exchange;
    [XmlElement] public Quest.Require require;
    
    
    public class Ingredient {
        [XmlAttribute] public int id;
        [XmlAttribute] public int rank;
        [XmlAttribute] public int count;
    }

    public partial class Require {
        public partial class Item {
            [M2dArray] public string[] id = Array.Empty<string>();
        }
        [XmlAttribute] public long meso;
    }
}
