using System.ComponentModel;
using System.Xml.Serialization;

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
        [XmlAttribute] public float optionLevelFactor = 1.0f;
        [XmlIgnore] public float? globalOptionLevelFactor;
        [XmlAttribute] public int optionID;

        /* Custom Attribute Serializers */
        [XmlAttribute("globalOptionLevelFactor"), DefaultValue(null)]
        public string _globalOptionLevelFactor {
            get => globalOptionLevelFactor?.ToString();
            set => globalOptionLevelFactor = float.TryParse(value, out float n) ? n : null;
        }
    }
}