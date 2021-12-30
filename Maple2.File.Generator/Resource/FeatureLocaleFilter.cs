using System;
using System.Collections.Generic;
using System.Linq;

namespace M2dXmlGenerator {
    public static class FeatureLocaleFilter {
        public static string Locale = string.Empty;
        public static HashSet<string> Features = new HashSet<string>();

        public static T FeatureLocale<T>(this T result) where T : IFeatureLocale {
            if (result != null && FeatureEnabled(result.Feature) && HasLocale(result.Locale)) {
                return result;
            }

            return default(T);
        }

        public static T FirstFeatureLocale<T>(this IEnumerable<T> results) where T : IFeatureLocale {
            return results.Where(data => FeatureEnabled(data.Feature)).FirstByLocale();
        }

        public static IEnumerable<T> FeatureLocale<T>(this IEnumerable<T> results) where T : IFeatureLocale {
            return results.Where(data => FeatureEnabled(data.Feature) && HasLocale(data.Locale));
        }

        public static IEnumerable<T> FeatureLocale<T, TK>(this IEnumerable<T> results, Func<T, TK> groupSelector) where T : IFeatureLocale {
            return results.Where(data => FeatureEnabled(data.Feature))
                .GroupBy(groupSelector)
                .FirstByLocale();
        }

        private static bool FeatureEnabled(string feature) {
            return string.IsNullOrEmpty(feature) || Features.Contains(feature);
        }

        private static bool HasLocale(string locale) {
            return string.IsNullOrEmpty(locale) || Locale.Equals(locale, StringComparison.OrdinalIgnoreCase);
        }

        private static IEnumerable<TE> FirstByLocale<TK, TE>(this IEnumerable<IGrouping<TK, TE>> enumerable) where TE : IFeatureLocale {
            foreach (IGrouping<TK, TE> grouping in enumerable) {
                TE result = grouping.FirstByLocale();
                if (result != null) {
                    yield return result;
                }
            }
        }

        private static T FirstByLocale<T>(this IEnumerable<T> enumerable) where T : IFeatureLocale {
            // If no matches, just return null.
            var result = default(T);
            foreach (T entry in enumerable) {
                // Matching locale is always returned.
                if (Locale.Equals(entry.Locale, StringComparison.OrdinalIgnoreCase)) {
                    return entry;
                }

                // Empty locale will be returned by default if no exact match.
                if (string.IsNullOrEmpty(entry.Locale)) {
                    result = result ?? entry;
                }
            }

            return result;
        }
    }
}
