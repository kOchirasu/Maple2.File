using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IDecoItemNIF : IMesh {
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
    }
}
