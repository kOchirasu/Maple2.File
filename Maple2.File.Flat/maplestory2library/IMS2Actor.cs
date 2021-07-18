using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Actor : IActor, IMS2TextKeyCallback, IMS2Reaction {
        bool MinimapInVisible => true;
        bool PauseEnable => false;
        float PauseTime => 0;
        string PauseEffect => "";
    }
}
