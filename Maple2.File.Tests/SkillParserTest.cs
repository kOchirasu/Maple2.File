using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Skill;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class SkillParserTest {
    [TestMethod]
    public void TestSkillParser() {
        var parser = new SkillParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, string name, SkillData data) in parser.Parse()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(9915, count);
    }
}
