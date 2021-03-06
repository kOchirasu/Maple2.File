using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Skill.Property {
    public class SplashManualActiveProperty {
        [XmlIgnore] public int[] splashSkillIDs; // csv
        [XmlAttribute] public bool onlyManualActiveSplash;

        /* Custom Attribute Serializers */
        [XmlAttribute("splashSkillIDs")]
        public string _splashSkillIDs {
            get => Serialize.IntCsv(splashSkillIDs);
            set => splashSkillIDs = Deserialize.IntCsv(value);
        }
    }
}