using System;
using System.Collections.Generic;
using System.Linq;

namespace Maple2.File.Parser.Tools;

internal static class EnumerableExtensions {
    internal static IEnumerable<TE> FirstByLocale<TK, TE>(this IEnumerable<IGrouping<TK, TE>> enumerable, Filter filter,
        Func<TE, string> localeSelector) {
        foreach (IGrouping<TK, TE> grouping in enumerable) {
            TE result = grouping.FirstByLocale(filter, localeSelector);
            if (result != null) {
                yield return result;
            }
        }
    }

    // Returns a single result by locale priority:
    // 1. Explicitly set locale matches filter
    // 2. Empty locale
    // 3. No matches (NULL)
    internal static T FirstByLocale<T>(this IEnumerable<T> enumerable, Filter filter, Func<T, string> localeSelector) {
        var result = default(T);
        foreach (T entry in enumerable) {
            if (!filter.HasLocale(localeSelector(entry))) continue;

            if (filter.Locale.Equals(localeSelector(entry), StringComparison.OrdinalIgnoreCase)) {
                return entry;
            }

            result ??= entry;
        }

        return result;
    }
}
