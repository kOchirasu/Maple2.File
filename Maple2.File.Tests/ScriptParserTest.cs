using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Script;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class ScriptParserTest {
    [TestMethod]
    public void TestNpcScriptParser() {
        var parser = new ScriptParser(TestUtils.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.NpcSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NpcSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, NpcScript script) in parser.ParseNpc()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(script);
            count++;
        }
        Assert.AreEqual(3352, count);
    }

    [TestMethod]
    public void TestQuestScriptParser() {
        var parser = new ScriptParser(TestUtils.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.NpcSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NpcSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach (QuestScript script in parser.ParseQuest()) {
            Assert.IsNotNull(script);
            count++;
        }
        Assert.AreEqual(4210, count);
    }

    [TestMethod]
    public void TestStringsParser() {
        var parser = new ScriptParser(TestUtils.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.NpcSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NpcSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((string key, string value) in parser.ParseStrings()) {
            Assert.IsNotNull(key);
            Assert.IsNotNull(value);
            count++;
        }
        Assert.AreEqual(20124, count);
    }
}
