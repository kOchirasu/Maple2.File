using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml {
    [XmlRoot("ms2")]
    public class AdditionalEffectLevelData {
        [XmlElement] public List<AdditionalEffectData> level;
    }
}