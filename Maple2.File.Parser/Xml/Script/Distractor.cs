using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Script; 

public class Distractor {
    [XmlAttribute] public string text = string.Empty;
    [XmlAttribute("goto")] public string @goto = string.Empty;
    [XmlAttribute] public string gotoFail = string.Empty;
}