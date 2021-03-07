using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class ResetSkillCoolDownTimeProperty {
        [XmlIgnore] public int[] skillCodes = Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("skillCodes")]
        public string _skillCodes {
            get => Serialize.IntCsv(skillCodes);
            set => skillCodes = Deserialize.IntCsv(value);
        }
    }
}