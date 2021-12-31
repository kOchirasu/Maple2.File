#nullable enable
using System;
using System.Xml.Serialization;

namespace M2dXmlGenerator;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class M2dNullableAttribute : XmlIgnoreAttribute {
    public M2dNullableAttribute() { }

    public string? Name { get; set; }
}
