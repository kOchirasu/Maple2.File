using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.String;

[XmlRoot("ms2")]
public class StringMapping {
    [XmlElement] public List<Key> key;

    internal Dictionary<int, string> Filter(Filter filter) {
        return key
            .Where(k => filter.FeatureEnabled(k.feature))
            .GroupBy(k => k.id)
            .Select(grouping => grouping.First())
            .ToDictionary(k => k.id, k => k.name);
    }
}
