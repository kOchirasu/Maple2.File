namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2MannequinEquipItem : IMS2EquipItem, IExceptLightService {
        bool IsVisible => false;
        bool IsCastingShadow => false;
    }
}
