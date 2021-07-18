using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2NolightableMesh : IMesh, IExceptLightService {
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
    }
}
