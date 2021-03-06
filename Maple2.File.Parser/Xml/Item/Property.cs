using System.ComponentModel;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Item {
    public class Property {
        [XmlAttribute] public int skin;
        [XmlAttribute] public int skinType;
        [XmlAttribute] public int slotMax = 1; // if > 99999, set to 99999
        [XmlAttribute] public int type;
        [XmlAttribute] public int subtype;
        [XmlAttribute] public int itemGroup;
        [XmlAttribute] public int collection;
        [XmlAttribute] public int doNotPreview;
        [XmlAttribute] public int doNotSkipRender;
        [XmlAttribute] public int survival;
        [XmlAttribute] public int useSurvival;
        [XmlAttribute] public int applyFatiguePenalty;
        [XmlAttribute] public string category;
        [XmlAttribute] public string blackMarketCategory;
        [XmlAttribute] public int iconCode;
        [XmlAttribute] public int representOption = 35; // if -1 then 35 (real default is -1)
        [XmlAttribute] public string slotIcon = "icon0.png";
        [XmlAttribute] public string slotIconCustom;
        [XmlAttribute] public string movie;
        [XmlAttribute] public string xmlData;
        [XmlAttribute] public string presetPath;
        [XmlAttribute] public bool remakeDisable;
        [XmlAttribute] public int reference;
        [XmlAttribute] public int gearScore;
        [XmlAttribute] public int unlimitedEnchantMaxGrade;
        [XmlAttribute] public int socketDataId;
        [XmlAttribute] public string functionTags;
        [XmlAttribute] public int moveDisable;
        [XmlAttribute] public bool disableDrop;

        [XmlElement] public Sell sell;
        [XmlElement] public Exp exp;

        // Handle versioning
        [XmlIgnore]
        public int tradableCount =>
            Deserialize.Overrides(int.MinValue, _globalTradableCountNA, _globalTradableCount, _tradableCount);
        [XmlAttribute("tradableCount")]
        public int _tradableCount;
        [XmlAttribute("globalTradableCount"), DefaultValue(int.MinValue)]
        public int _globalTradableCount = int.MinValue;
        [XmlAttribute("globalTradableCountNA"), DefaultValue(int.MinValue)]
        public int _globalTradableCountNA = int.MinValue;

        [XmlIgnore]
        public int tradableCountDeduction =>
            Deserialize.Overrides(int.MinValue, _globalTradableCountDeduction, _tradableCountDeduction);
        [XmlAttribute("tradableCountDeduction")]
        public int _tradableCountDeduction;
        [XmlAttribute("globalTradableCountDeduction"), DefaultValue(int.MinValue)]
        public int _globalTradableCountDeduction = int.MinValue;

        [XmlIgnore]
        public int rePackingLimitCount =>
            Deserialize.Overrides(int.MinValue, _globalRePackingLimitCount, _rePackingLimitCount);
        [XmlAttribute("rePackingLimitCount")]
        public int _rePackingLimitCount;
        [XmlAttribute("globalRePackingLimitCount"), DefaultValue(int.MinValue)]
        public int _globalRePackingLimitCount = int.MinValue;

        [XmlIgnore]
        public int rePackingItemConsumeCount =>
            Deserialize.Overrides(int.MinValue, _globalRePackingItemConsumeCount, _rePackingItemConsumeCount);
        [XmlAttribute("rePackingItemConsumeCount")]
        public int _rePackingItemConsumeCount;
        [XmlAttribute("globalRePackingItemConsumeCount"), DefaultValue(int.MinValue)]
        public int _globalRePackingItemConsumeCount = int.MinValue;

        [XmlIgnore]
        public int[] rePackingScrollID =>
            Deserialize.IntCsv(Deserialize.StringOverrides(_globalRePackingScrollID, _rePackingScrollID));
        [XmlAttribute("rePackingScrollID"), DefaultValue(null)]
        public string _rePackingScrollID;
        [XmlAttribute("globalRePackingScrollID"), DefaultValue(null)]
        public string _globalRePackingScrollID;

        public class Sell {
            [XmlIgnore] public long[] price;
            [XmlIgnore] public long[] priceCustom;

            /* Custom Attribute Serializers */
            [XmlAttribute("price")]
            public string _price {
                get => Serialize.LongCsv(price);
                set => price = Deserialize.LongCsv(value);
            }

            [XmlAttribute("priceCustom")]
            public string _priceCustom {
                get => Serialize.LongCsv(priceCustom);
                set => priceCustom = Deserialize.LongCsv(value);
            }
        }

        public class Exp {
            [XmlAttribute] public long attackExp;
            [XmlAttribute] public long lifeExp;
            [XmlAttribute] public long adventureExp;
        }
    }
}