using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser.Tools;

public class Filter {
    public readonly string Locale;
    public readonly HashSet<string> Features;

    public Filter(string locale, IEnumerable<string> features) {
        Locale = locale;
        Features = new HashSet<string>(features);
    }

    // locale: TW, TH, NA, CN, JP, KR
    // env: Dev, Qa, DevStage, Stage, Live
    public static Filter Load(M2dReader xmlReader, string locale, string env) {
        var settingSerializer = new XmlSerializer(typeof(FeatureSetting));
        var featureSerializer = new XmlSerializer(typeof(FeatureRoot));

        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("feature_setting.xml"));
        var featureSetting = (FeatureSetting) settingSerializer.Deserialize(reader);
        Setting setting = featureSetting.setting.First(setting => setting.type == env);
        reader = xmlReader.GetXmlReader(xmlReader.GetEntry("feature.xml"));
        var featureRoot = (FeatureRoot) featureSerializer.Deserialize(reader);

        HashSet<string> features = featureRoot.feature.Where(feature => {
            return locale switch {
                "TW" => feature.TW <= setting.TW,
                "TH" => feature.TH <= setting.TH,
                "NA" => feature.NA <= setting.NA,
                "CN" => feature.CN <= setting.CN,
                "JP" => feature.JP <= setting.JP,
                "KR" => feature.KR <= setting.KR,
                _ => throw new ArgumentException($"Unsupported locale: {locale}"),
            };
        }).Select(feature => feature.name).ToHashSet();

        return new Filter(locale, features);
    }

    public bool FeatureEnabled(string feature) {
        return string.IsNullOrEmpty(feature) || Features.Contains(feature);
    }

    public bool HasLocale(string checkLocale) {
        return string.IsNullOrEmpty(checkLocale) || Locale.Equals(checkLocale, StringComparison.OrdinalIgnoreCase);
    }
}
