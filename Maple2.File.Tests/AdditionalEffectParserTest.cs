using Maple2.File.Parser;
using Maple2.File.Parser.Xml.AdditionalEffect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class AdditionalEffectParserTest {
    [TestMethod]
    public void TestAdditionalEffectParser() {
        var parser = new AdditionalEffectParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, IList<AdditionalEffectData> data) in parser.Parse()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(6079, count);
    }
}
