using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Map;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class MapParser {
    private readonly M2dReader xmlReader;
    private readonly Filter filter;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer mapSerializer;

    public MapParser(M2dReader xmlReader, Filter filter) {
        this.xmlReader = xmlReader;
        this.filter = filter;
        this.nameSerializer = new XmlSerializer(typeof(StringMapping));
        this.mapSerializer = new XmlSerializer(typeof(MapEnvironmentData));
    }

    public IEnumerable<(int Id, string Name, MapData Data)> Parse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/mapname.xml"));
        var mapping = nameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> mapNames = mapping.Filter(filter);

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("map/"))) {
            reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeMap(xmlReader.GetString(entry))));
            var root = mapSerializer.Deserialize(reader) as MapEnvironmentData;
            Debug.Assert(root != null);

            MapData data = root.Filter(filter);
            if (data == null) continue;

            int mapId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (mapId, mapNames.GetValueOrDefault(mapId), data);
        }
    }
}
