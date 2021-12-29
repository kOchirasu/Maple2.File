using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect; 

public class DotDamageProperty {
    [XmlAttribute] public int type;
    [XmlAttribute] public int useGrade;
    [XmlAttribute] public int value;
    [XmlAttribute] public float rate;
    [XmlAttribute] public int spValue;
    [XmlAttribute] public int epValue;
    [XmlAttribute] public int hand;
    [XmlAttribute] public int element;
    [XmlAttribute] public float damageByTargetMaxHP;
    [XmlAttribute] public float casterRecoveryHpByDamage;
    [XmlAttribute] public int soundMaterial;
    [XmlAttribute] public int isConstDotDamageValue;
    [XmlAttribute] public int notKill;
    [XmlAttribute] public long damageRefBap;
    [XmlAttribute] public long damageRefWap;
    [XmlAttribute] public long damageRefTap;
}

public class DotBuffProperty {
    [XmlAttribute] public int target;
    [XmlAttribute] public int buffID;
    [XmlAttribute] public short buffLevel;
}