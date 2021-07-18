using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastAreaLight : IPointLight, IBeastLight, IPrecomputedLightConfig {
        bool CastShadows => true;
        bool LightNonPCLObjectsAtRuntime => false;
    }
}
