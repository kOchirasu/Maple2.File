using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class MapParserTest {
    [TestMethod]
    public void TestMapParser() {
        var parser = new MapParser(TestUtils.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.MapSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.MapSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        foreach ((int id, string name, MapData data) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Map: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
        }
    }
}
