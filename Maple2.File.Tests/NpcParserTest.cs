using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Npc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests; 

[TestClass]
public class NpcParserTest {
    [TestMethod]
    public void TestNpcParser() {
        var parser = new NpcParser(TestUtils.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.NpcSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NpcSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, NpcData data, List<EffectDummy> dummy) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Npc: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(7402, count);
    }
}
