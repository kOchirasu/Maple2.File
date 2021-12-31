using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Script;

public partial class TalkScript : IFeatureLocale {
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
}