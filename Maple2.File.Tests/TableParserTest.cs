using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class TableParserTest {
    [TestMethod]
    public void TestColorPaletteParser() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseColorPalette()) {
            continue;
        }

        foreach ((_, _) in parser.ParseColorPaletteAchieve()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDefaultItemsParser() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _, _) in parser.ParseDefaultItems()) {
            continue;
        }
    }

    [TestMethod]
    public void TestItemBreakIngredientParser() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemBreakIngredient()) {
            continue;
        }
    }

    [TestMethod]
    public void TestItemGemstoneUpgradeParser() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemGemstoneUpgrade()) {
            continue;
        }
    }

    private record struct Obj(int a, int b, int c);

    [TestMethod]
    public void Test() {
        var a = new List<Obj>();
        a.Add(new Obj(1, 2, 3));
        a.Add(new Obj(1, 2, 4));
        a.Add(new Obj(1, 2, 5));
        a.Add(new Obj(1, 3, 6));
        a.Add(new Obj(2, 2, 7));
        a.Add(new Obj(1, 2, 3));

        foreach (IGrouping<(int a, int b), Obj> group in a.GroupBy(select => (select.a, select.b))) {
            Console.WriteLine($"{group.Key}:");
            foreach (Obj result in group) {
                Console.WriteLine($"- {result}");
            }
        }
    }

    [TestMethod]
    public void TestJobTableParser() {
        var parser = new TableParser(TestUtils.XmlReader);

        Dictionary<int, List<JobTable>> results = parser.ParseJobTable()
            .GroupBy(result => result.code)
            .ToDictionary(group => group.Key, group => group.ToList());

        var expected = new Dictionary<int, string> {
            {1, ""},
            {10, "JobChange_02"},
            {20, "JobChange_02"},
            {30, "JobChange_02"},
            {40, "JobChange_02"},
            {50, "JobChange_02"},
            {60, "JobChange_02"},
            {70, "JobChange_02"},
            {80, "JobChange_02"},
            {90, "JobChange_02"},
            {100, "JobChange_02"},
            {110, "JobChange_02"},
        };
        foreach ((int jobCode, string feature) in expected) {
            Assert.IsTrue(results.TryGetValue(jobCode, out List<JobTable>? job));
            Assert.IsNotNull(job);
            // Ensure that FeatureLocale was filtered properly
            Assert.AreEqual(1, job.Count);
            Assert.AreEqual(job[0].Feature, feature);
            // Ensure that some value was parsed
            Assert.IsTrue(job[0].skills.skill.Count > 0);
            Assert.IsTrue(job[0].learn.Count > 0);
        }
    }

    [TestMethod]
    public void TestSetItemOptionParser() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseSetItemOption()) {
            continue;
        }
    }
}
