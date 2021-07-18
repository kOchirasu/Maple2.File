namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPCLDirectionalLight : IPrecomputedLightConfig, IDirectionalLight {
        bool CastShadows => true;
    }
}
