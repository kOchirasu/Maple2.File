using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildbuff.xml
[XmlRoot("ms2")]
public class GuildBuffRoot {
    [XmlElement] public List<GuildBuff> guildBuff;
}

public partial class GuildBuff : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int level;
    [XmlAttribute] public int additionalEffectId;
    [XmlAttribute] public int additionalEffectLevel;
    [XmlAttribute] public int requireLevel;
    [XmlAttribute] public int upgradeCost;
    [XmlAttribute] public int cost;
    [XmlAttribute] public int duration;
    [XmlAttribute] public int cooltime;
    [XmlAttribute] public byte type;
    [XmlAttribute] public string functionName = string.Empty;
}
