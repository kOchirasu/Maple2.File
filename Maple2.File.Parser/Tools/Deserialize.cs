using System;
using System.Drawing;

namespace Maple2.File.Parser.Tools; 

internal static class Deserialize {
    public static Color Color(string value) {
        byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(value, 16));
        bytes[3] = bytes[3] == 0 ? (byte) 0xFF : bytes[3]; // Alpha 255 if not set

        return System.Drawing.Color.FromArgb(bytes[3], bytes[0], bytes[1], bytes[2]);
    }
}