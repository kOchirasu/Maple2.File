namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPrecomputedLightConfig : IPrecomputedLighting {
        bool LightPCLObjectsAtRuntime => false;
        bool LightNonPCLObjectsAtRuntime => true;
    }
}
