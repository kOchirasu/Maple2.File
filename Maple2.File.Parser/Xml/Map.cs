using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Map;

namespace Maple2.File.Parser.Xml {
    // ./data/xml/map/%08d.xml
    [XmlRoot("ms2")]
    public class MapEnvironmentData {
        [XmlElement] public List<MapData> environment;
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
}