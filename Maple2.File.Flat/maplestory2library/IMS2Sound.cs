using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Sound : I3DProxy, IMS2TimeAmbSetting {
        float SoundRadius => 1500;
        string soundEventID => "";
        string ProxyNifAsset => "urn:llid:340609da-0000-0000-0000-000000000000";
    }
}
