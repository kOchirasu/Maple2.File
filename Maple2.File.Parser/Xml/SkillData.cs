using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Skill;

namespace Maple2.File.Parser.Xml {
    [XmlRoot("ms2")]
    public class SkillData {
        [XmlAttribute] public string feature;

        [XmlElement] public List<Basic> basic;
        [XmlElement] public List<SkillLevelData> level;
    }
}