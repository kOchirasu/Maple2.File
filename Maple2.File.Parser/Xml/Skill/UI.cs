using System.ComponentModel;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill {
    public class UI {
        [XmlAttribute] public string icon;
        [XmlAttribute] public string movie;
        [XmlAttribute] public int exceptUI;
        [XmlAttribute, DefaultValue(0)] public int attackType;
        [XmlAttribute] public bool disableChangeSkillIconEffect;
        [XmlAttribute] public bool showCastingBar;
        [XmlAttribute] public string tooltip;
        [XmlAttribute] public string paramCastingBar; // escaped html
    }
}