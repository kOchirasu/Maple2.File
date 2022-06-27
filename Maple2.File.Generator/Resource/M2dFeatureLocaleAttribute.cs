#nullable enable
using System;
using System.Xml.Serialization;

namespace M2dXmlGenerator;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class M2dFeatureLocaleAttribute : XmlIgnoreAttribute {
    public M2dFeatureLocaleAttribute() { }

    public string? Name { get; set; }

    /// <summary>
    /// Used to group the field that is being feature gated.
    ///
    /// For Example:
    ///     <entry key="num" value="1">
    ///     <entry key="num" value="10" locale="NA">
    ///
    /// Selector would be 'key'
    /// </summary>
    /// <remarks>
    /// To specify multiple selectors, separate each with '|'.
    /// </remarks>
    public string? Selector { get; set; }
}
