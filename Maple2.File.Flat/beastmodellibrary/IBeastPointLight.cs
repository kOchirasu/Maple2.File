using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastPointLight : IPCLPointLight, IBeastLight {
        float ilbShadowRadius => 0;
    }
}
