using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml;
using Maple2.File.Parser.Xml.Npc;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class NpcParser {
    private readonly M2dReader xmlReader;
    private readonly Filter filter;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer npcSerializer;

    public NpcParser(M2dReader xmlReader, Filter filter) {
        this.xmlReader = xmlReader;
        this.filter = filter;
        this.nameSerializer = new XmlSerializer(typeof(StringMapping));
        this.npcSerializer = new XmlSerializer(typeof(NpcEnvironmentData));
    }

    public IEnumerable<(int Id, string Name, NpcData Data, List<EffectDummy>)> Parse() {
        XmlReader reader = xmlReader.GetXmlReader("en/npcname.xml");
        var mapping = nameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> npcNames = mapping.Filter(filter);

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("npc/"))) {
            var root = npcSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as NpcEnvironmentData;
            Debug.Assert(root != null);

            (NpcData data, List<EffectDummy> effectDummies) = root.Filter(filter);
            if (data == null) continue;

            int npcId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (npcId, npcNames.GetValueOrDefault(npcId), data, effectDummies);
        }
    }
}
