using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table; 

// ./data/xml/table/defaultitems.xml
[XmlRoot("ms2")]
public partial class DefaultItems {
    [M2dFeatureLocale(Selector = "jobCode")] private IList<Key> _key;

    public partial class Key : IFeatureLocale {
        [XmlAttribute] public int jobCode;
    }

    public partial class Slot {
        [M2dFeatureLocale(Selector = "id")] private IList<Item> _item;
        
        [XmlAttribute] public string name = string.Empty;
    }

    public partial class Item : IFeatureLocale {
        [XmlAttribute] public int id;
        [XmlAttribute] public bool visible;
        [XmlAttribute("base")] public bool @base;
        [XmlAttribute] public bool select;
        [XmlAttribute] public int saleTag;
    }
}
