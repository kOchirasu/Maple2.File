using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/shop_beautycoupon.xml
[XmlRoot("ms2")]
public partial class ShopBeautyCouponRoot {
    [M2dFeatureLocale(Selector = "shopID")] private IList<ShopBeautyCoupon> _shop;
}

public partial class ShopBeautyCoupon : IFeatureLocale {
    [XmlAttribute] public int shopID;
    [XmlAttribute] public byte byItem;
    [XmlElement] public List<Item> item;
    
    public partial class Item {
        [XmlAttribute] public int id;
    }
}