using System;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc {
    public class DropItemInfo {
        [XmlAttribute] public float dropHeight;
        [XmlAttribute] public float dropDistanceBase = 50.0f;
        [XmlAttribute] public int dropDistanceRandom = 100;
        [XmlAttribute] public float fireVelocity = 100.0f;
        [XmlIgnore] public int[] globalDropBoxId = Array.Empty<int>();
        [XmlIgnore] public int[] globalDeadDropBoxId = Array.Empty<int>();
        [XmlIgnore] public int[] individualDropBoxId = Array.Empty<int>();
        [XmlIgnore] public int[] globalHitDropBoxId = Array.Empty<int>();
        [XmlIgnore] public int[] individualHitDropBoxId = Array.Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("globalDropBoxId")]
        public string _globalDropBoxId {
            get => Serialize.IntCsv(globalDropBoxId);
            set => globalDropBoxId = Deserialize.IntCsv(value);
        }

        [XmlAttribute("globalDeadDropBoxId")]
        public string _globalDeadDropBoxId {
            get => Serialize.IntCsv(globalDeadDropBoxId);
            set => globalDeadDropBoxId = Deserialize.IntCsv(value);
        }

        [XmlAttribute("individualDropBoxId")]
        public string _individualDropBoxId {
            get => Serialize.IntCsv(individualDropBoxId);
            set => individualDropBoxId = Deserialize.IntCsv(value);
        }

        [XmlAttribute("globalHitDropBoxId")]
        public string _globalHitDropBoxId {
            get => Serialize.IntCsv(globalHitDropBoxId);
            set => globalHitDropBoxId = Deserialize.IntCsv(value);
        }

        [XmlAttribute("individualHitDropBoxId")]
        public string _individualHitDropBoxId {
            get => Serialize.IntCsv(individualHitDropBoxId);
            set => individualHitDropBoxId = Deserialize.IntCsv(value);
        }

        // Ignored by client.
        [XmlAttribute] public string globalDropBoxIdLevel1 = string.Empty;
        [XmlAttribute] public string globalDropBoxIdLevel2 = string.Empty;
        [XmlAttribute] public string globalDropBoxIdLevel3 = string.Empty;
    }
}