namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPCLActor : IActor, IPrecomputedLightReceiver {
        bool UseLightProbes => true;
    }
}
