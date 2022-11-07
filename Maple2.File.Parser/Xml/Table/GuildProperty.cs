using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildproperty.xml
[XmlRoot("ms2")]
public class GuildPropertyRoot {
    [XmlElement] public List<GuildProperty> property;
}

public partial class GuildProperty : IFeatureLocale {
    [XmlAttribute] public int level;
    [XmlAttribute] public int accumExp;
    [XmlAttribute] public int capacity;
    [XmlAttribute] public long fundMaxx;
    [XmlAttribute] public int donationMax;
    [XmlAttribute] public int attendGuildExp;
    [XmlAttribute] public int winMiniGameGuildExp;
    [XmlAttribute] public int loseMiniGameGuildExp;
    [XmlAttribute] public int raidGuildExp;
    [XmlAttribute] public long attendGuildFund;
    [XmlAttribute] public long winMiniGameGuildFund;
    [XmlAttribute] public long loseMiniGameGuildFund;
    [XmlAttribute] public long raidGuildFund;
    [XmlAttribute] public int attendUserExpFactor;
    [XmlAttribute] public float donationUserExpFactor;
    [XmlAttribute] public int attendGuildCoin;
    [XmlAttribute] public int donateGuildCoin;
    [XmlAttribute] public int winMiniGameGuildCoin;
    [XmlAttribute] public int loseMiniGameGuildCoin;
}
