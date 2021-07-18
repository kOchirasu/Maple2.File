using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2VibrateNoPhysX : IMS2MapProperties, IMS2Vibrate, IMesh {
        bool IsStatic => true;
    }
}
