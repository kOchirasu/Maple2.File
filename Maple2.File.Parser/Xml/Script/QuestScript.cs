using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Script;

// ./data/xml/script/quest/%s.xml
[XmlRoot("ms2")]
public class QuestScriptRoot {
    [XmlElement] public List<QuestScript> quest;
}

public class QuestScript {
    [XmlAttribute] public int id;

    [XmlElement] public List<TalkScript> script;

    internal QuestScript Filter(Filter filter) {
        return new QuestScript {
            id = this.id,
            script = TalkScript.Filter(script, filter).ToList(),
        };
    }
}
