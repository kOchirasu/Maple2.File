using System.Collections.Generic;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMultiProxy : IProxy {
        IDictionary<string, string> AttachedObjects => new Dictionary<string, string>();
    }
}
