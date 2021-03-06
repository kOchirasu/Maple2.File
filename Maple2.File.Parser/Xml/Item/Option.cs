using System.ComponentModel;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Item {
    public class Option {
        [XmlAttribute] public int title;
        [XmlAttribute("static")] public int @static;
        [XmlAttribute] public int random;
        [XmlAttribute] public int constant;
        [XmlAttribute] public int staticMakeType;
        [XmlAttribute] public int randomMakeType;
        [XmlAttribute] public int constantMakeType;
        [XmlAttribute] public int optionRandom;
        [XmlAttribute] public int optionID;

        // Handle versioning
        [XmlIgnore]
        public float optionLevelFactor =>
            Deserialize.Overrides(float.MinValue, _globalOptionLevelFactor, _optionLevelFactor);
        [XmlAttribute("optionLevelFactor")]
        public float _optionLevelFactor = 1.0f;
        [XmlAttribute("globalOptionLevelFactor"), DefaultValue(float.MinValue)]
        public float _globalOptionLevelFactor = float.MinValue;
    }
}