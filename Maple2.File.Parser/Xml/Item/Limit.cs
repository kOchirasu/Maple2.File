using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item; 

public partial class Limit {
    [XmlAttribute] public int genderLimit = 2;
    [XmlAttribute] public int levelLimit = 1;
    [XmlAttribute] public int levelLimitMax;
    [XmlAttribute] public int transferType;
    [M2dNullable] public int? globalTransferType;
    [M2dNullable] public int? globalTransferTypeNA;
    [XmlAttribute] public int transferTypeVersion;
    [XmlAttribute] public int shopSell;
    [XmlAttribute] public int enableBreak;
    [XmlAttribute] public int enableRegisterMeratMarket;
    [XmlAttribute] public int exceptEnchant;
    [XmlAttribute] public int vip;
    [XmlAttribute] public int wedding;
    [XmlAttribute] public int tradeLimitRank = 4;
    [XmlAttribute] public int vipLevel;
    [XmlAttribute] public bool enableSocketTransfer = true;
    [M2dArray] public int[] jobLimit = Array.Empty<int>();
    [M2dArray] public int[] disableJobLimit = Array.Empty<int>();
    [M2dArray] public int[] recommendJobs = Array.Empty<int>();
}