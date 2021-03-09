using System.ComponentModel;
using System;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Item {
    public class Limit {
        [XmlAttribute] public int genderLimit = 2;
        [XmlAttribute] public int levelLimit = 1;
        [XmlAttribute] public int levelLimitMax;
        [XmlAttribute] public int transferType;
        [XmlIgnore] public int? globalTransferType;
        [XmlIgnore] public int? globalTransferTypeNA;
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
        [XmlIgnore] public int[] jobLimit = Array.Empty<int>();
        [XmlIgnore] public int[] disableJobLimit = Array.Empty<int>();
        [XmlIgnore] public int[] recommendJobs = Array.Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("globalTransferType"), DefaultValue(null)]
        public string _globalTransferType {
            get => globalTransferType?.ToString();
            set => globalTransferType = int.TryParse(value, out int n) ? n : null;
        }

        [XmlAttribute("globalTransferTypeNA"), DefaultValue(null)]
        public string _globalTransferTypeNA {
            get => globalTransferTypeNA?.ToString();
            set => globalTransferTypeNA = int.TryParse(value, out int n) ? n : null;
        }

        [XmlAttribute("jobLimit")]
        public string _jobLimit {
            get => Serialize.IntCsv(jobLimit);
            set => jobLimit = Deserialize.IntCsv(value);
        }

        [XmlAttribute("disableJobLimit")]
        public string _disableJobLimit {
            get => Serialize.IntCsv(disableJobLimit);
            set => disableJobLimit = Deserialize.IntCsv(value);
        }

        [XmlAttribute("recommendJobs")]
        public string _recommendJobs {
            get => Serialize.IntCsv(recommendJobs);
            set => recommendJobs = Deserialize.IntCsv(value);
        }
    }
}