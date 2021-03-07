using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

// ./data/xml/table/magicPath.xml
namespace Maple2.File.Parser.Xml {
    [XmlRoot("ms2")]
    public class MagicPath {
        [XmlElement] public List<MagicType> type;
    }

    public class MagicType {
        [XmlAttribute] public long id;

        [XmlElement] public List<MagicData> move;
    }

    public class MagicData {
        [XmlIgnore] public Vector3 fireOffsetPosition;
        [XmlIgnore] public Vector3 fireFixedPosition;
        [XmlAttribute] public string fireNode = string.Empty;
        [XmlIgnore] public Vector3 direction = Vector3.UnitX;
        [XmlAttribute] public float dirRotZDegree;
        [XmlIgnore] public Vector3 controlValue0;
        [XmlIgnore] public Vector3 controlValue1;
        [XmlIgnore] public Vector3 controlEndOffsetValue;
        [XmlAttribute] public float lifeTime;
        [XmlAttribute] public float delayTime;
        [XmlAttribute] public float spawnTime;
        [XmlAttribute] public bool ignoreCancelAtSpawnTime;
        [XmlAttribute] public float vel;
        [XmlAttribute] public float distance;
        [XmlAttribute] public float nonTargetMoveDistance;
        [XmlAttribute] public float destroyTime;
        [XmlAttribute] public float controlRate;
        [XmlAttribute] public int lookAtType;
        [XmlAttribute] public int catmullrom;
        [XmlAttribute] public int rotation = 1;
        [XmlAttribute] public float traceTargetDuration;
        [XmlAttribute] public bool explosionByDestroy = true;
        [XmlAttribute] public bool traceTargetOffsetPos;
        [XmlAttribute] public bool ignorePhysxTestInitPosition;
        [XmlAttribute] public int piercingAttackInterval;
        [XmlAttribute] public int piercingAttackMaxTargetCount;
        [XmlAttribute] public int moveEndHoldDuration;
        //public float timeInterval => vel / distance;

        /* Custom Attribute Serializers */
        [XmlAttribute("fireOffsetPosition")]
        public string _fireOffsetPosition {
            get => Serialize.Vector3(fireOffsetPosition);
            set => fireOffsetPosition = Deserialize.Vector3(value);
        }

        [XmlAttribute("fireFixedPosition")]
        public string _fireFixedPosition {
            get => Serialize.Vector3(fireFixedPosition);
            set => fireFixedPosition = Deserialize.Vector3(value);
        }

        [XmlAttribute("direction")]
        public string _direction {
            get => Serialize.Vector3(direction);
            set => direction = Deserialize.Vector3(value);
        }

        [XmlAttribute("controlValue0")]
        public string _controlValue0 {
            get => Serialize.Vector3(controlValue0);
            set => controlValue0 = Deserialize.Vector3(value);
        }

        [XmlAttribute("controlValue1")]
        public string _controlValue1 {
            get => Serialize.Vector3(controlValue1);
            set => controlValue1 = Deserialize.Vector3(value);
        }

        [XmlAttribute("controlEndOffsetValue")]
        public string _controlEndOffsetValue {
            get => Serialize.Vector3(controlEndOffsetValue);
            set => controlEndOffsetValue = Deserialize.Vector3(value);
        }

        /*[XmlAttribute("lifeTime")]
        public string _lifeTime {
            get => lifeTime.ToString(CultureInfo.InvariantCulture);
            set => lifeTime = Deserialize.Float(value);
        }

        [XmlAttribute("delayTime")]
        public string _delayTime {
            get => delayTime.ToString(CultureInfo.InvariantCulture);
            set => delayTime = Deserialize.Float(value);
        }

        [XmlAttribute("spawnTime")]
        public string _spawnTime {
            get => spawnTime.ToString(CultureInfo.InvariantCulture);
            set => spawnTime = Deserialize.Float(value);
        }

        [XmlAttribute("vel")]
        public string _vel {
            get => vel.ToString(CultureInfo.InvariantCulture);
            set => vel = Deserialize.Float(value);
        }

        [XmlAttribute("distance")]
        public string _distance {
            get => distance.ToString(CultureInfo.InvariantCulture);
            set => distance = Deserialize.Float(value);
        }

        [XmlAttribute("destroyTime")]
        public string _destroyTime {
            get => destroyTime.ToString(CultureInfo.InvariantCulture);
            set => destroyTime = Deserialize.Float(value);
        }

        [XmlAttribute("controlRate")]
        public string _controlRate {
            get => controlRate.ToString(CultureInfo.InvariantCulture);
            set => controlRate = Deserialize.Float(value);
        }*/

        // Ignored by client.
        [XmlAttribute] public bool align;
        [XmlAttribute] public int alignCubeHeight;
        [XmlAttribute] public bool ignoreAdjustCubePosition;
    }
}