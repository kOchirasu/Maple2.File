namespace Maple2.File.Flat.triggerslibrary {
    public interface IEntitiesDeadSource : IAbstractTriggerSource {
        string ModelToCheck => "Enemy";
        uint CheckFrequencyMs => 500;
        bool CheckActive => true;
        string TriggerID => "EntitiesDead";
    }
}
