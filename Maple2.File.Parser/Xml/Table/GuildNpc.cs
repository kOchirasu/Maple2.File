using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildnpc.xml
[XmlRoot("ms2")]
public class GuildNpcRoot {
    [XmlElement] public List<GuildNpc> npc;
}

public partial class GuildNpc : IFeatureLocale {
    [M2dEnum] public GuildNpcType type;
    [XmlAttribute] public int level;
    [XmlAttribute] public long upgradeCost;
    [XmlAttribute] public int requireGuildLevel;
    [XmlAttribute] public int requireHouseLevel;
    [XmlAttribute] public string stringKey;
}
