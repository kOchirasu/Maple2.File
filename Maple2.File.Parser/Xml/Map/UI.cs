using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map; 

public class UI {
    [XmlAttribute] public string bgMask = string.Empty;
    [XmlAttribute] public int vscroll = 1;
    [XmlAttribute] public int hscroll = 1;
    [XmlAttribute] public int useEffLight;
    [XmlAttribute] public int fieldName = 1;
    [XmlAttribute] public int effectLOD = 1;
    [XmlAttribute] public int instancingGrid;
    [XmlAttribute] public int fallDamage = 1;
    [XmlAttribute] public int useEPSkill = 1;
    [XmlAttribute] public int useRidee = 1;
    [XmlAttribute] public int usePet = 1;
    [XmlAttribute] public int globalNameTag;
    [XmlAttribute] public int useOptimalHide = 1;
    [XmlAttribute] public int showHitEffect = 1;
    [XmlAttribute] public int applyCameraOption = 1;
    [XmlAttribute] public float cameraExtraDistance;
    [XmlAttribute] public bool isNoSkipFrame;
    [XmlAttribute] public int autoFindTaxiStation = 1;
    [XmlAttribute] public string mapEffectId = string.Empty;

    // Ignored by client.
    [XmlAttribute] public int playOneTime;
}