using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill {
    public class Basic {
        [XmlAttribute] public string feature;

        [XmlElement] public UI ui;
        [XmlElement] public Kinds kinds;
        [XmlElement] public StateAttribute stateAttr;
    }

    public class Feature {
        [XmlAttribute] public string feature;
    }
}