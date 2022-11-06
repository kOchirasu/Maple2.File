using Maple2.File.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class ItemOptionParserTest {
    [TestMethod]
    public void TestItemOptionParser() {
        var parser = new ItemOptionParser(TestUtils.XmlReader);

        foreach (var data in parser.ParseConstant()) {
            Assert.IsNotNull(data);
        }
        foreach (var data in parser.ParseRandom()) {
            Assert.IsNotNull(data);
        }
        foreach (var data in parser.ParseStatic()) {
            Assert.IsNotNull(data);
        }
    }

    [TestMethod]
    public void TestItemMergeOptionParser() {
        var parser = new ItemOptionParser(TestUtils.XmlReader);

        foreach (var data in parser.ParseMergeOptionBase()) {
            Assert.IsNotNull(data);
        }
        foreach (var data in parser.ParseMergeOptionMaterial()) {
            Assert.IsNotNull(data);
        }
    }

    [TestMethod]
    public void TestItemOptionPickParser() {
        var parser = new ItemOptionParser(TestUtils.XmlReader);

        foreach (var data in parser.ParsePick()) {
            Assert.IsNotNull(data);
        }
    }

    [TestMethod]
    public void TestItemOptionVariationParser() {
        var parser = new ItemOptionParser(TestUtils.XmlReader);

        foreach (var data in parser.ParseVariation()) {
            Assert.IsNotNull(data);
        }
        foreach (var data in parser.ParseVariationEquip()) {
            Assert.IsNotNull(data.Option);
        }
    }
}
