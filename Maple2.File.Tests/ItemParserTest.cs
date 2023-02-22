using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class ItemParserTest {
    [TestMethod]
    public void TestItemParser() {
        var parser = new ItemParser(TestUtils.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.ItemSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.ItemSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        foreach ((int id, string name, ItemData data) in parser.Parse()) {
            // Debug.WriteLine($"Parsing item: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
        }
    }
}
