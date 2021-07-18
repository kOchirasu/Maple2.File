namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPSSMDirectionalLight : IDirectionalLight, IParallelSplitShadowConfig {
        bool CastShadows => true;
    }
}
