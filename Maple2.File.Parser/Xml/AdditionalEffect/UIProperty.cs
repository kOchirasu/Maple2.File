using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public class UIProperty {
    [XmlAttribute] public int iconOnOff = 1; // 0,1,2,3,4,5,6,7,8,9,10,11,12
    [XmlAttribute] public bool iconBalloonOnOff;
    [XmlAttribute] public bool isHideCooltime;
    [XmlAttribute] public bool priority;
    [XmlAttribute] public bool infinitySP;
    [XmlAttribute] public bool visibleItemOption = true;
    [XmlAttribute] public int cinematicPlay; // 0
    [XmlAttribute] public string icon = string.Empty;
}
