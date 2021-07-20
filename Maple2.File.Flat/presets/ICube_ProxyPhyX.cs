using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.maplestory2library;

namespace Maple2.File.Flat.presets {
    public interface ICube_ProxyPhyX : IMS2PhysXProp {
        string ModelName => "Cube_ProxyPhyX";
        Vector3 VisualizedCubeSize => new Vector3(150, 150, 150);
        Vector3 VisualizedCubeOffset => new Vector3(0, 0, 75);
        Color VisualizedCubeColor => Color.FromArgb(255, 255, 255, 255);
        ushort PropCollisionGroup => 9;
    }
}
