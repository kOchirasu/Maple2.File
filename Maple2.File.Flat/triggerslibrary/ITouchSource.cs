namespace Maple2.File.Flat.triggerslibrary {
    public interface ITouchSource : IAbstractTriggerSource {
        bool isTouchable => true;
        string TriggerID => "Touched";
    }
}
