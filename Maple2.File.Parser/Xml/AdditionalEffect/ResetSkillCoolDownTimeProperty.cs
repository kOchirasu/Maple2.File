using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class ResetSkillCoolDownTimeProperty {
        [XmlIgnore] public int[] skillCodes; // csv

        /* Custom Attribute Serializers */
        [XmlAttribute("skillCodes")]
        public string _skillCodes {
            get => Serialize.IntCsv(skillCodes);
            set => skillCodes = Deserialize.IntCsv(value);
        }
    }
}