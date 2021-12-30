using System;
using System.Xml.Serialization;

namespace M2dXmlGenerator {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class M2dFeatureLocaleAttribute : XmlIgnoreAttribute {
        public M2dFeatureLocaleAttribute() { }

        public string? Name { get; set; }

        public string? Selector { get; set; }
    }
}