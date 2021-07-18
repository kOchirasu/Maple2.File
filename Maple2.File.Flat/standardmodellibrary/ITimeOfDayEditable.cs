using System.Collections.Generic;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface ITimeOfDayEditable {
        string TimeOfDayAssetPath => "";
        IDictionary<string, string> TimeOfDayAnimatablePropertyList => new Dictionary<string, string>();
    }
}
