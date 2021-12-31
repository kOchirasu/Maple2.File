#nullable enable
using System;
using System.Xml.Serialization;

namespace M2dXmlGenerator;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class M2dEnumAttribute : XmlIgnoreAttribute {
    public M2dEnumAttribute() { }

    public string? Name { get; set; }
}
