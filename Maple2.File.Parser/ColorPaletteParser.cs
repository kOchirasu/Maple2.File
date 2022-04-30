using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser; 

public class ColorPaletteParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer paletteSerializer;

    public ColorPaletteParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.paletteSerializer = new XmlSerializer(typeof(ColorPaletteRoot));
    }

    public IEnumerable<(int Id, ColorPalette Palette)> Parse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/colorpalette.xml"));
        var data = paletteSerializer.Deserialize(reader) as ColorPaletteRoot;
        Debug.Assert(data != null);

        foreach (ColorPalette palette in data.color) {
            yield return (palette.id, palette);
        }
    }
    
    public IEnumerable<(int Id, ColorPalette Palette)> ParseAchieve() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("colorpalette_achieve.xml"));
        var data = paletteSerializer.Deserialize(reader) as ColorPaletteRoot;
        Debug.Assert(data != null);

        foreach (ColorPalette palette in data.color) {
            yield return (palette.id, palette);
        }
    }
}
