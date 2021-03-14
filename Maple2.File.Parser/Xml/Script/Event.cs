using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Script {
    public class Event {
        [XmlAttribute] public int id;

        [XmlElement] public List<Content> content;
    }
}