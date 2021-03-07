using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class UIProperty {
        [XmlAttribute] public int iconOnOff = 1;
        [XmlAttribute] public int iconBalloonOnOff;
        [XmlAttribute] public int isHideCooltime;
        [XmlAttribute] public int priority;
        [XmlAttribute] public int infinitySP;
        [XmlAttribute] public int visibleItemOption = 1;
        [XmlAttribute] public int cinematicPlay;
        [XmlAttribute] public string icon = string.Empty;
    }
}