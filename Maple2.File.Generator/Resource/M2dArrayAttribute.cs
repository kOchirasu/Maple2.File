using System;
using System.Xml.Serialization;

namespace M2dXmlGenerator {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class M2dArrayAttribute : XmlIgnoreAttribute {
        public M2dArrayAttribute() { }

        public string? Name { get; set; }
        public char Delimiter { get; set; } = ',';
    }
}