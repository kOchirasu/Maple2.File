using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Common {
    [XmlType(Namespace = "Common")]
    public partial class Condition {
        [XmlAttribute] public string type = string.Empty; // ConditionType
        [XmlAttribute] public long value;
        [M2dArray] public string[] code = Array.Empty<string>(); // split on ',' and '-'
        [M2dArray] public string[] target = Array.Empty<string>(); // split on ',' and ':'
        [XmlAttribute] public int partyCount;
        [XmlAttribute] public int guildPartyCount;
    }
}
