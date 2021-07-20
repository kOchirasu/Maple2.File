using System;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest {
    public partial class Navigation {
        [XmlAttribute] public string type = NavigationType.unknown.ToString(); // NavigationType
        [M2dArray] public int[] code = Array.Empty<int>();
        [M2dArray] public int[] map = Array.Empty<int>();
    }
}
