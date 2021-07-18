namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastBakePreferences {
        string ilbPreferredBakeTarget => "Texture";
        string ilbPreferredBakeType => "RNM";
        uint ilbAtlasSize => 1024;
        float ilbRatioScale => 0.01f;
    }
}
