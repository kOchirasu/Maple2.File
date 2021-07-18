using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Fluid : ICubeBrushablePhysXProp {
        string CubeType => "Fluid";
        Vector3 ShapeDimensions => default;
    }
}
