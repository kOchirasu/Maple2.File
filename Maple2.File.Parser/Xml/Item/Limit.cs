using System.ComponentModel;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Item {
    public class Limit {
        [XmlAttribute] public int genderLimit = 2;
        [XmlAttribute] public int levelLimit = 1;
        [XmlAttribute] public int levelLimitMax;
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
        [XmlIgnore] public int[] jobLimit;
        [XmlIgnore] public int[] disableJobLimit;
        [XmlIgnore] public int[] recommendJobs;

        // Handle versioning
        [XmlIgnore]
        public int transferType =>
            Deserialize.Overrides(int.MinValue, _globalTransferTypeNA, _globalTransferType, _transferType);
        [XmlAttribute("transferType")]
        public int _transferType;
        [XmlAttribute("globalTransferType"), DefaultValue(int.MinValue)]
        public int _globalTransferType = int.MinValue;
        [XmlAttribute("globalTransferTypeNA"), DefaultValue(int.MinValue)]
        public int _globalTransferTypeNA = int.MinValue;

        /* Custom Attribute Serializers */
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