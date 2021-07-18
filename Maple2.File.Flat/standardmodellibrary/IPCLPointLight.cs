namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPCLPointLight : IPrecomputedLightConfig, IPointLight {
        bool CastShadows => true;
    }
}
