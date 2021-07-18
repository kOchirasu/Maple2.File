namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPCLSpotLight : ISpotLight, IPrecomputedLightConfig {
        bool CastShadows => true;
    }
}
