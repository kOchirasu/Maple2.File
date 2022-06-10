using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.String;

public partial class Key : IFeatureLocale {
    [XmlAttribute] public string name = string.Empty;
    [XmlAttribute] public string id;
}
