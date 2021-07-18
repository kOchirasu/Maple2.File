namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastLight {
        float ilbDirectLightScale => 1;
        float ilbIndirectLightScale => 1;
        ushort ilbShadowSamples => 1;
        ushort ilbMinShadowSamples => 1;
    }
}
