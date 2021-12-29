using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Map;

// ./data/xml/map/%08d.xml
[XmlRoot("ms2")]
public class MapEnvironmentData {
    [XmlElement] public List<MapData> environment;

    internal MapData Filter(Filter filter) {
        return environment
            .Where(data => filter.FeatureEnabled(data.feature))
            .FirstByLocale(filter, data => data.locale);
    }
}

public class MapData {
    [XmlAttribute] public string feature = string.Empty;
    [XmlAttribute] public string locale = string.Empty;

    [XmlElement] public XBlock xblock;
    [XmlElement] public Property property;
    [XmlElement] public Drop drop;
    [XmlElement] public Split split;
    [XmlElement] public CashCall cashCall;
    [XmlElement] public Indoor indoor;
    [XmlElement] public UI ui;
    [XmlElement] public BGM bgm;
    [XmlElement] public HDR hdr;
    [XmlElement] public Survival survival;
    [XmlElement] public Camera camera;
    [XmlElement] public Shadow shadow;
    [XmlElement] public FOV fov;
    [XmlElement] public Optimize optimize;
    [XmlElement] public WorldMap worldmap; // Ignored by client.
}