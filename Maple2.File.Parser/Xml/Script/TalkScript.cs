using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Script;

public partial class TalkScript {
    [XmlAttribute] public string feature = string.Empty;
    [XmlAttribute] public string locale = string.Empty;

    [XmlAttribute] public int id;
    [XmlAttribute] public bool randomPick;
    [XmlAttribute] public int popupProp;
    [XmlAttribute] public int popupState;
    [M2dArray] public int[] gotoConditionTalkID;
    [XmlAttribute] public int jobCondition;

    [XmlElement] public List<Content> content;

    // Ignored by client.
    //[XmlAttribute] public string buttonSet; // "roulette"
    //[XmlAttribute] public string tag; // "limitFameGrade"

    internal static IEnumerable<TalkScript> Filter(IEnumerable<TalkScript> enumerable, Filter filter) {
        return enumerable?.Where(talk => filter.FeatureEnabled(talk.feature))
            .GroupBy(talk => talk.id)
            .FirstByLocale(filter, talk => talk.locale);
    }
}