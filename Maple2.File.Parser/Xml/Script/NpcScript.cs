using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Script;

// ./data/xml/script/npc/%08d.xml
[XmlRoot("ms2")]
public class NpcScript {
    [XmlElement] public List<TalkScript> select;
    [XmlElement] public TalkScript job;
    [XmlElement] public List<TalkScript> monologue;
    [XmlElement] public List<TalkScript> script;

    internal NpcScript Filter(Filter filter) {
        TalkScript filteredJob = job;
        if (job != null && (!filter.FeatureEnabled(job.feature) || filter.HasLocale(job.locale))) {
            filteredJob = null;
        }

        return new NpcScript {
            select = TalkScript.Filter(select, filter).ToList(),
            job = filteredJob,
            monologue = TalkScript.Filter(monologue, filter).ToList(),
            script = TalkScript.Filter(script, filter).ToList(),
        };
    }
}
