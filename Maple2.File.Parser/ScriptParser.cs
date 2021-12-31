using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.Script;

namespace Maple2.File.Parser;

public class ScriptParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer npcScriptSerializer;
    private readonly XmlSerializer questScriptSerializer;

    public ScriptParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.npcScriptSerializer = new XmlSerializer(typeof(NpcScript));
        this.questScriptSerializer = new XmlSerializer(typeof(QuestScriptRoot));
    }

    public IEnumerable<(int Id, NpcScript Script)> ParseNpc() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("script/npc"))) {
            var root = npcScriptSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as NpcScript;
            Debug.Assert(root != null);

            int npcId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (npcId, root);
        }
    }

    public IEnumerable<QuestScript> ParseQuest() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("script/quest"))) {
            var root = questScriptSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as QuestScriptRoot;
            Debug.Assert(root != null);

            foreach (QuestScript quest in root.quest) {
                yield return quest;
            }
        }
    }
}
