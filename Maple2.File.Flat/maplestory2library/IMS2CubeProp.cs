using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2CubeProp : IMS2PhysXProp, ICubeBrushable {
        int skillID => 0;
        int skillLevel => 0;
        ushort PropCollisionGroup => 9;
        Vector3 ShapeDimensions => default;
        string InstallStackable => "3,4,5";
        bool InstallWall => true;
        string InstallStackableD => "3,4,5";
    }
}
