using System.Xml.Serialization;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest {
    public class Notify {
        [XmlAttribute] public string completeUiEffect = UiEffect.unknown.ToString(); // UiEffect
        [XmlAttribute] public string acceptSoundKey = string.Empty;
        [XmlAttribute] public string completeSoundKey = string.Empty;
    }
}