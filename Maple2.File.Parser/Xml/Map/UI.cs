using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map;

public class UI {
    [XmlAttribute] public string bgMask = string.Empty;
    [XmlAttribute] public bool vscroll = true;
    [XmlAttribute] public bool hscroll = true;
    [XmlAttribute] public bool useEffLight;
    [XmlAttribute] public bool fieldName = true;
    [XmlAttribute] public bool effectLOD = true;
    [XmlAttribute] public int instancingGrid;
    [XmlAttribute] public bool fallDamage = true;
    [XmlAttribute] public bool useEPSkill = true;
    [XmlAttribute] public bool useRidee = true;
    [XmlAttribute] public bool usePet = true;
    [XmlAttribute] public bool globalNameTag;
    [XmlAttribute] public bool useOptimalHide = true;
    [XmlAttribute] public bool showHitEffect = true;
    [XmlAttribute] public bool applyCameraOption = true;
    [XmlAttribute] public float cameraExtraDistance;
    [XmlAttribute] public bool isNoSkipFrame;
    [XmlAttribute] public bool autoFindTaxiStation = true;
    [XmlAttribute] public string mapEffectId = string.Empty;

    // Ignored by client.
    [XmlAttribute] public bool playOneTime;
}
