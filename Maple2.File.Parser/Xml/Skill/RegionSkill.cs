using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Skill {
    public class RegionSkill {
        [XmlAttribute] public int includeCaster;
        [XmlAttribute] public string rangeType; // box, cylinder, frustum, hole_cylinder
        [XmlAttribute] public float distance;
        [XmlIgnore] public Vector3 rangeAdd;
        [XmlIgnore] public Vector3 rangeOffset;
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
        [XmlIgnore] public int[] applyTargetIgnoreNpcRanks;

        /* Custom Attribute Serializers */
        [XmlAttribute("rangeAdd")]
        public string _rangeAdd {
            get => Serialize.Vector3(rangeAdd);
            set => rangeAdd = Deserialize.Vector3(value);
        }

        [XmlAttribute("rangeOffset")]
        public string _rangeOffset {
            get => Serialize.Vector3(rangeOffset);
            set => rangeOffset = Deserialize.Vector3(value);
        }

        [XmlAttribute("applyTargetIgnoreNpcRanks")]
        public string _applyTargetIgnoreNpcRanks {
            get => Serialize.IntCsv(applyTargetIgnoreNpcRanks);
            set => applyTargetIgnoreNpcRanks = Deserialize.IntCsv(value);
        }

        // Ignored by client.
        [XmlAttribute] public int targetSelectHasBuffType;
        [XmlAttribute] public int onlyTargetSelectHasBuff;
    }
}