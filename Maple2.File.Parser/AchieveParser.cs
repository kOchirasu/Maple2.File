using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Achieve;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class AchieveParser {
    private readonly M2dReader xmlReader;
    private readonly Filter filter;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer achieveSerializer;

    public AchieveParser(M2dReader xmlReader, Filter filter) {
        this.xmlReader = xmlReader;
        this.filter = filter;
        this.nameSerializer = new XmlSerializer(typeof(StringMapping));
        this.achieveSerializer = new XmlSerializer(typeof(AchievesData));
    }

    public IEnumerable<(int Id, string Name, AchieveData Data)> Parse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/achievename.xml"));
        var mapping = nameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> achieveNames = mapping.Filter(filter);

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("achieve/"))) {
            reader = XmlReader.Create(new StringReader(Sanitizer.RemoveEmpty(xmlReader.GetString(entry))));
            var root = achieveSerializer.Deserialize(reader) as AchievesData;
            Debug.Assert(root != null);

            AchieveData data = root.Filter(filter);
            if (data == null) continue;

            int achieveId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (achieveId, achieveNames.GetValueOrDefault(achieveId), data);
        }
    }
}
