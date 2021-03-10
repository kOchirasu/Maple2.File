using System.Numerics;
using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill {
    public partial class RegionSkill {
        [XmlAttribute] public int includeCaster;
        [XmlAttribute] public string rangeType = string.Empty; // box, cylinder, frustum, hole_cylinder
        [XmlAttribute] public float distance;
        [M2dVector3] public Vector3 rangeAdd;
        [M2dVector3] public Vector3 rangeOffset;
        [XmlAttribute] public float rangeZRotateDegree;
        [XmlAttribute] public float height;
        [XmlAttribute] public float width;
        [XmlAttribute] public float endWidth;
        [XmlAttribute] public int applyTarget;
        [XmlAttribute] public int castTarget;
        [XmlAttribute] public int sensorStartDelay; // 0
        [XmlAttribute] public int sensorSplashStartDelay; // 0
        [XmlAttribute] public int sensorForceInvokeByInterval;
        [XmlAttribute] public int targetHasBuffID;
        [XmlAttribute] public int targetHasBuffOverlapCount;
        [XmlAttribute] public int targetHasNotBuffID;
        [XmlAttribute] public int targetHasBuffOwner;
        [XmlAttribute] public int targetSelectType;
        [XmlAttribute] public bool targetSelectParty;
        [XmlAttribute] public bool targetSelectGuild;
        [XmlAttribute] public int targetStatCompare;
        [XmlAttribute] public int targetStatCompareFunction;
        [M2dArray] public int[] applyTargetIgnoreNpcRanks = Array.Empty<int>();

        // Ignored by client.
        [XmlAttribute] public int targetSelectHasBuffType;
        [XmlAttribute] public int onlyTargetSelectHasBuff;
    }
}