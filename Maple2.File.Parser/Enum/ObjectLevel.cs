using System.Xml.Serialization;

namespace Maple2.File.Parser.Enum;

public enum ObjectLevel {
    DungeonLevel = -2,
    mapLevel = -1,
    [XmlEnum("0")] _0 = 0,
    [XmlEnum("21")] _21 = 21,
    [XmlEnum("31")] _31 = 31,
    [XmlEnum("36")] _36 = 36,
    [XmlEnum("46")] _46 = 46,
    [XmlEnum("50")] _50 = 50,
    [XmlEnum("99")] _99 = 99,
}
