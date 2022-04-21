#nullable enable
using System;
using System.Xml.Serialization;

namespace M2dXmlGenerator;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class M2dColorAttribute : XmlIgnoreAttribute {
    public M2dColorAttribute() { }

    public string? Name { get; set; }
}
