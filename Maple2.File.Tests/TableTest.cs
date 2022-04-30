using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests; 

[TestClass]
public class TableTest {
    [TestMethod]
    public void TestColorPaletteParser() {
        var parser = new ColorPaletteParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.Parse()) {
            continue;
        }
        
        foreach ((_, _) in parser.ParseAchieve()) {
            continue;
        }
    }
    
    [TestMethod]
    public void TestDefaultItemsParser() {
        var parser = new DefaultItemsParser(TestUtils.XmlReader);

        foreach ((_, _, _) in parser.Parse()) {
            continue;
        }
    }
    
    [TestMethod]
    public void TestJobTableParser() {
        var parser = new JobTableParser(TestUtils.XmlReader);

        foreach (JobTable _ in parser.Parse()) {
            continue;
        }
    }
}
