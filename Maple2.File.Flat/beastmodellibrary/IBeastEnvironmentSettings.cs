using System.Drawing;

namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastEnvironmentSettings {
        string ilbEnvironment => "None";
        string ilbHDRFile => "";
        float ilbHDRBlur => 0;
        float ilbHDRRotation => 0;
        Color ilbEnvironmentColor => Color.FromArgb(255, 97, 188, 211);
        float ilbHDRIntensity => 1;
    }
}
