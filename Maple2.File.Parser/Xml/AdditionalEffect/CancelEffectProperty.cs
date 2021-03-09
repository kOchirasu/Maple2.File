using System;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class CancelEffectProperty {
        [XmlAttribute] public int cancelCheckSameCaster;
        [XmlAttribute] public int cancelPassiveEffect;
        [XmlIgnore] public int[] cancelEffectCodes = Array.Empty<int>();
        [XmlIgnore] public int[] cancelBuffCategories = Array.Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("cancelEffectCodes")]
        public string _cancelEffectCodes {
            get => Serialize.IntCsv(cancelEffectCodes);
            set => cancelEffectCodes = Deserialize.IntCsv(value);
        }

        [XmlAttribute("cancelBuffCategories")]
        public string _cancelBuffCategories {
            get => Serialize.IntCsv(cancelBuffCategories);
            set => cancelBuffCategories = Deserialize.IntCsv(value);
        }
    }
}