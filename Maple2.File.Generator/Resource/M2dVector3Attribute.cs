#nullable enable
using System;
using System.Xml.Serialization;

namespace M2dXmlGenerator;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class M2dVector3Attribute : XmlIgnoreAttribute {
    public M2dVector3Attribute() { }

    public string? Name { get; set; }
}
