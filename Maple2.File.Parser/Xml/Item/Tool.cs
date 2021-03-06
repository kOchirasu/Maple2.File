using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item {
    public class Tool {
        [XmlAttribute] public string itemPreset;
        [XmlAttribute] public string itemPresetPath;
    }
}