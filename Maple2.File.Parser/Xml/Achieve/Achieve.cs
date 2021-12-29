using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Achieve;

// ./data/xml/achieve/%08d.xml
[XmlRoot("ms2")]
public class AchievesData {
    [XmlElement] public List<AchieveData> achieves;

    internal AchieveData Filter(Filter filter) {
        return achieves
            .Where(data => filter.FeatureEnabled(data.feature))
            .FirstOrDefault(data => filter.HasLocale(data.locale));
    }
}

public partial class AchieveData {
    [XmlAttribute] public string feature = string.Empty;
    [XmlAttribute] public string locale = string.Empty;

    [XmlAttribute] public int id;
    [XmlAttribute] public int noticePercent = 1;
    [XmlAttribute] public short standardLevel;
    [XmlAttribute] public bool account;
    [XmlAttribute] public bool locking;
    [XmlAttribute] public string contentsTag = string.Empty; // "*Survival*" treated specially
    [M2dArray] public string[] categoryTag = Array.Empty<string>();
    [XmlAttribute] public string uiFilterType = string.Empty;
    [M2dArray] public string[] uiFilterValue = Array.Empty<string>();
    [XmlAttribute] public string icon = string.Empty;

    [XmlElement] public List<Grade> grade;
}