using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IDropItemNIF : IMesh {
        bool IsStatic => true;
        bool IsReceivingShadow => false;
    }
}
