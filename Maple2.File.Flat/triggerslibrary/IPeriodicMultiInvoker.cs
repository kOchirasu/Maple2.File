using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.triggerslibrary {
    public interface IPeriodicMultiInvoker : IPeriodicTriggerSource, IMultiTargetResponse, IPlaceable {
        uint ActivationCount => 0;
        uint MaxActivations => 1;
    }
}
