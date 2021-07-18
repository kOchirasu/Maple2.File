using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2PhysXSceneForItem : IMS2PhysXScene {
        Vector3 Gravity => new Vector3(0, 0, -9.8f);
        string SceneName => "PhysXItemSceneName";
    }
}
