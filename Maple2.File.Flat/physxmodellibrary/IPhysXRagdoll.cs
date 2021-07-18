using System.Collections.Generic;

namespace Maple2.File.Flat.physxmodellibrary {
    public interface IPhysXRagdoll : IPhysXProp {
        IDictionary<string, string> PhysicalSequences => new Dictionary<string, string>();
    }
}
