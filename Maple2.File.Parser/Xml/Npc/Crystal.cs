using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class Crystals {
        [XmlElement] public List<Crystal> crystal;
    }

    public class Crystal {
        [XmlAttribute] public string id = string.Empty;
        [XmlIgnore] public int[] level = Array.Empty<int>();
        [XmlIgnore] public int[] price = Array.Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("level")]
        public string _level {
            get => Serialize.IntCsv(level);
            set => level = Deserialize.IntCsv(value);
        }

        [XmlAttribute("price")]
        public string _price {
            get => Serialize.IntCsv(price);
            set => price = Deserialize.IntCsv(value);
        }
    }
}