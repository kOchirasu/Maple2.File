using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Quest {
    public class Remote {
        [XmlAttribute] public string useRemote = string.Empty; // UseRemoteType
        [XmlAttribute] public int requireField;
        [XmlAttribute] public int requireDungeonClear;
    }
}
