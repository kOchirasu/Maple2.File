using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildcontribution.xml
[XmlRoot("ms2")]
public class GuildContributionRoot {
    [XmlElement] public List<GuildContribution> contribution;
}

public partial class GuildContribution : IFeatureLocale {
    [M2dEnum] public GuildContributionType Type;
    [XmlAttribute] public int value;
}
