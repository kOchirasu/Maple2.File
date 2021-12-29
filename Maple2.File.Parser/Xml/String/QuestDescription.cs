using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.String;

// TODO: Validate with IDA against client.
// ./data/xml/string/en/questdescription*.xml
[XmlRoot("ms2")]
public class QuestDescriptionRoot {
    [XmlElement] public List<QuestDescription> quest;

    internal List<QuestDescription> Filter(Filter filter) {
        return quest
            .GroupBy(description => description.questID)
            .FirstByLocale(filter, description => description.locale)
            .ToList();
    }
}

public partial class QuestDescription {
    [XmlAttribute] public string locale = string.Empty;

    [XmlAttribute] public bool locking;
    [M2dArray(Delimiter = '|')] public int[] count = Array.Empty<int>();
    [XmlAttribute] public string complete = string.Empty;
    [M2dArray(Delimiter = '|')] public string[] manual = Array.Empty<string>();
    [XmlAttribute] public string desc = string.Empty;
    [XmlAttribute] public string name = string.Empty;
    [XmlAttribute] public int questID;
}
