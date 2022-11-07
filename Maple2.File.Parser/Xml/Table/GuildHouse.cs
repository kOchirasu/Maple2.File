using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildhouse.xml
[XmlRoot("ms2")]
public class GuildHouseRoot {
    [XmlElement] public List<GuildHouse> guildHouse;
}

public partial class GuildHouse : IFeatureLocale {
    [XmlAttribute] public int level;
    [XmlAttribute] public byte theme;
    [XmlAttribute] public int fieldID;
    [XmlAttribute] public int upgradeReqGuildLevel;
    [XmlAttribute] public long upgradeCost;
    [XmlAttribute] public long rethemeCost;
    [XmlAttribute] public byte areaSize;
    [M2dArray] public int[] facility = Array.Empty<int>();
}
