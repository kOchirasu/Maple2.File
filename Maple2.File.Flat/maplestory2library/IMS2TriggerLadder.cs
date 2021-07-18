namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerLadder : ILadder, IMS2TriggerObject {
        string hideEffectXml => "";
        string showEffectXml => "";
        float ExtrudeOffset => -20;
    }
}
