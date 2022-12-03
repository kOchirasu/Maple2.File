using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/individualitemdrop.xml
// ./data/xml/table/individualitemdrop_charge.xml
// ./data/xml/table/individualitemdrop_event.xml
// ./data/xml/table/individualitemdrop_eventnpc.xml
// ./data/xml/table/individualitemdrop_newgacha.xml
// ./data/xml/table/individualitemdrop_pet.xml
// ./data/xml/table/individualitemdrop_quest_obj.xml
// ./data/xml/table/na/individualitemdrop_gacha.xml
// ./data/xml/table/na/individualitemdrop_gearbox.xml
[XmlRoot("ms2")]
public partial class IndividualItemDropRoot {
    [M2dFeatureLocale(Selector = "individualDropBoxID")] private IList<IndividualItemDrop> _individualDropBox;
}

public partial class IndividualItemDrop : IFeatureLocale {
    [XmlAttribute] public int individualDropBoxID;
    [XmlAttribute] public byte dropGroup;
    [XmlAttribute] public int item;
    [XmlAttribute] public int item2;
    [XmlAttribute] public int smartDropRate;
    [XmlAttribute] public string isApplySmartGenderDrop = string.Empty;
    [XmlAttribute] public byte showTooltip;
    [XmlAttribute] public bool showIconOnGachaUI;
    [XmlAttribute] public int enchantLevel;
    [XmlAttribute] public float minCount;
    [XmlAttribute] public float maxCount;
    [M2dNullable] public int? socketDataID;
    [M2dNullable] public int? PackageUIShowGrade;
}
