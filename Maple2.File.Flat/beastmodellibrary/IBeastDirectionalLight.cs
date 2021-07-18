using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastDirectionalLight : IPCLDirectionalLight, IBeastLight {
        float ilbShadowAngle => 0;
    }
}
