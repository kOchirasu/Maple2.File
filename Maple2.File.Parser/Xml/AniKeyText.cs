using System.Collections.Generic;
using System.Xml.Serialization;

// ./data/xml/anikeytext.xml
namespace Maple2.File.Parser.Xml {
    [XmlRoot("ms2ani")]
    public class AnimationData {
        [XmlElement] public List<KeyFrameMotion> kfm;
    }

    public class KeyFrameMotion {
        [XmlAttribute] public string name = string.Empty;

        [XmlElement] public List<FrameSequence> seq;
    }

    public class FrameSequence {
        [XmlAttribute] public int id;
        [XmlAttribute] public string name = string.Empty;

        [XmlElement] public List<FrameSequenceKey> key;
    }

    public class FrameSequenceKey {
        [XmlAttribute] public string name = string.Empty;
        [XmlAttribute] public double time;
    }
}