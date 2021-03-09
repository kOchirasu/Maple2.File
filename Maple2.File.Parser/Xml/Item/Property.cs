using System.ComponentModel;
using System;
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
        [XmlAttribute] public string category = string.Empty;
        [XmlAttribute] public string blackMarketCategory = string.Empty;
        [XmlAttribute] public int iconCode;
        [XmlAttribute] public int representOption = 35; // if -1 then 35 (real default is -1)
        [XmlAttribute] public string slotIcon = "icon0.png";
        [XmlAttribute] public string slotIconCustom = string.Empty;
        [XmlAttribute] public string movie = string.Empty;
        [XmlAttribute] public string xmlData = string.Empty;
        [XmlAttribute] public string presetPath = string.Empty;
        [XmlAttribute] public bool remakeDisable;
        [XmlAttribute] public int reference;
        [XmlAttribute] public int gearScore;
        [XmlAttribute] public int tradableCount;
        [XmlIgnore] public int? globalTradableCount;
        [XmlIgnore] public int? globalTradableCountNA;
        [XmlAttribute] public int tradableCountDeduction;
        [XmlIgnore] public int? globalTradableCountDeduction;
        [XmlAttribute] public int unlimitedEnchantMaxGrade;
        [XmlAttribute] public int rePackingLimitCount;
        [XmlIgnore] public int? globalRePackingLimitCount;
        [XmlAttribute] public int rePackingItemConsumeCount;
        [XmlIgnore] public int? globalRePackingItemConsumeCount;
        [XmlIgnore] public int[] rePackingScrollID = Array.Empty<int>();
        [XmlIgnore] public int[] globalRePackingScrollID;
        [XmlAttribute] public int socketDataId;
        [XmlAttribute] public string functionTags = string.Empty;
        [XmlAttribute] public int moveDisable;
        [XmlAttribute] public bool disableDrop;

        [XmlElement] public Sell sell;
        [XmlElement] public Exp exp;

        /* Custom Attribute Serializers */
        [XmlAttribute("globalTradableCount"), DefaultValue(null)]
        public string _globalTradableCount {
            get => globalTradableCount?.ToString();
            set => globalTradableCount = int.TryParse(value, out int n) ? n : null;
        }

        [XmlAttribute("globalTradableCountNA"), DefaultValue(null)]
        public string _globalTradableCountNA {
            get => globalTradableCountNA?.ToString();
            set => globalTradableCountNA = int.TryParse(value, out int n) ? n : null;
        }

        [XmlAttribute("globalTradableCountDeduction"), DefaultValue(null)]
        public string _globalTradableCountDeduction {
            get => globalTradableCountDeduction?.ToString();
            set => globalTradableCountDeduction = int.TryParse(value, out int n) ? n : null;
        }

        [XmlAttribute("globalRePackingLimitCount"), DefaultValue(null)]
        public string _globalRePackingLimitCount {
            get => globalRePackingLimitCount?.ToString();
            set => globalRePackingLimitCount = int.TryParse(value, out int n) ? n : null;
        }

        [XmlAttribute("globalRePackingItemConsumeCount"), DefaultValue(null)]
        public string _globalRePackingItemConsumeCount {
            get => globalRePackingItemConsumeCount?.ToString();
            set => globalRePackingItemConsumeCount = int.TryParse(value, out int n) ? n : null;
        }

        [XmlAttribute("rePackingScrollID")]
        public string _rePackingScrollID {
            get => Serialize.IntCsv(rePackingScrollID);
            set => rePackingScrollID = Deserialize.IntCsv(value);
        }

        [XmlAttribute("globalRePackingScrollID"), DefaultValue(null)]
        public string _globalRePackingScrollID {
            get => Serialize.IntCsv(globalRePackingScrollID);
            set => globalRePackingScrollID = Deserialize.IntCsv(value);
        }

        public class Sell {
            [XmlIgnore] public long[] price = Array.Empty<long>();
            [XmlIgnore] public long[] priceCustom = Array.Empty<long>();

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