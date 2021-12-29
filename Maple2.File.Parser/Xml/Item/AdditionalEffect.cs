using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item; 

public partial class AdditionalEffect {
    [M2dArray] public int[] id = Array.Empty<int>();
    [M2dArray] public int[] level = Array.Empty<int>();
    [XmlAttribute] public bool dropEffect;
}