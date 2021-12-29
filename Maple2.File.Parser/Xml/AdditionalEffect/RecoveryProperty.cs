using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect; 

public class RecoveryProperty {
    [XmlAttribute] public int showUIText;
    [XmlAttribute] public float RecoveryRate;
    [XmlAttribute] public long hpValue;
    [XmlAttribute] public float hpRate;
    [XmlAttribute] public long spValue;
    [XmlAttribute] public float spRate;
    [XmlAttribute] public long epValue;
    [XmlAttribute] public float epRate;
    [XmlAttribute] public float hpConsumeRate;
    [XmlAttribute] public float spConsumeRate;
    [XmlAttribute] public int statChangeBase;
    [XmlAttribute] public int statChangeResult;
    [XmlAttribute] public float statChangeRate;
    [XmlAttribute] public int disableCriticalRecovery;
}