namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastMeshTextureBakeSettings {
        ushort ilbLightmapWidth => 64;
        ushort ilbLightmapHeight => 64;
        float ilbPackingRatio => 1;
        string ilbPackingMode => "Use Packing Ratio";
    }
}
