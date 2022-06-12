using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill;

public class UI {
    [XmlAttribute] public string icon = string.Empty;
    [XmlAttribute] public string movie = string.Empty;
    [XmlAttribute] public bool exceptUI;
    [XmlAttribute] public int attackType; // 0,1,2,3
    [XmlAttribute] public bool disableChangeSkillIconEffect;
    [XmlAttribute] public bool showCastingBar;
    [XmlAttribute] public string tooltip = string.Empty;
    [XmlAttribute] public string paramCastingBar = string.Empty; // escaped html
}
