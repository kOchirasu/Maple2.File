using System.Collections.Generic;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface ITerrain : IRenderable, IShadowable, ILightable, IPreloadable {
        ushort TerrainShadowLOD => 1;
        string TerrainAsset => "";
        IDictionary<string, uint> TerrainInitialSectors => new Dictionary<string, uint>();
    }
}
