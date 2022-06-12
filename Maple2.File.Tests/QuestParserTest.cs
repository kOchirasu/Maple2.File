using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Quest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class QuestParserTest {
    [TestMethod]
    public void TestQuestParser() {
        var parser = new QuestParser(TestUtils.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.QuestSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.QuestSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, QuestData data) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Quest: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }

        Assert.AreEqual(4740, count);
    }
}
