using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.AdditionalEffect;

namespace Maple2.File.Parser;

public class AdditionalEffectParser {
    private readonly M2dReader xmlReader;
    private readonly Filter filter;
    private readonly XmlSerializer effectSerializer;

    public AdditionalEffectParser(M2dReader xmlReader, Filter filter) {
        this.xmlReader = xmlReader;
        this.filter = filter;
        this.effectSerializer = new XmlSerializer(typeof(AdditionalEffectLevelData));
    }

    public IEnumerable<(int Id, List<AdditionalEffectData> Data)> Parse() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("additionaleffect/"))) {
            var root = effectSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as AdditionalEffectLevelData;
            Debug.Assert(root != null);

            List<AdditionalEffectData> data = root.Filter(filter);
            if (data == null) continue;

            int effectId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (effectId, data);
        }
    }
}
