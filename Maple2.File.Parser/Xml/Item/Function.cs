using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item {
    public class Function {
        [XmlAttribute] public string name;
        [XmlAttribute] public string parameter;
        [XmlAttribute] public int onlyShadowContinent;
    }
}