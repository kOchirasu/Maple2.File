using System.Diagnostics;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Tests; 

public static class TestUtils {
    private const string m2dPath = @"C:\Nexon\Library\Library\maplestory2\appdata\Data";
    public static readonly M2dReader XmlReader;

    static TestUtils() {
        XmlReader = new M2dReader(@$"{m2dPath}\Xml.m2d");
        Filter.Load(XmlReader, "NA", "Live");
    }

    public static void UnknownElementHandler(object? sender, XmlElementEventArgs e) {
        Debug.Print("Missing elements: {0}", e.ExpectedElements);
    }
    
    public static void UnknownAttributeHandler(object? sender, XmlAttributeEventArgs e) {
        Debug.Print("Missing attributes: {0}", e.ExpectedAttributes);
    }
}
