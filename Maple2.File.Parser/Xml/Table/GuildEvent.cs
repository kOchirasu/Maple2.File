using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildevent.xml
[XmlRoot("ms2")]
public class GuildEventRoot {
    [XmlElement] public List<GuildEvent> guildEvent;
}

public partial class GuildEvent : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int mapCode;
    [XmlAttribute] public int maxUserCount;
}
