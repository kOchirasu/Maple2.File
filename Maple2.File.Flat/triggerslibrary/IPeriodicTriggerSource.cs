namespace Maple2.File.Flat.triggerslibrary {
    public interface IPeriodicTriggerSource : IAbstractTriggerSource {
        uint StartDelay => 8000;
        float PeriodicInterval => 8000;
    }
}
