using Maple2.File.Flat;
using Maple2.File.Flat.maplestory2library;
using Maple2.File.Parser.Flat;
using Maple2.File.Parser.MapXBlock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class XBlockParserTest {
    [TestMethod]
    public void TestXBlockParser() {
        var index = new FlatTypeIndex(TestUtils.ExportedReader);
        var parser = new XBlockParser(TestUtils.ExportedReader, index);
        // Console.WriteLine(index.GetType("Portal_entrance").GetProperty("frontOffset"));

        parser.ParseMap("02000070_in", entities => {
            foreach (IMapEntity? entity in entities) {
                if (entity is IPortal portal) {
                    Console.WriteLine(entity.EntityName);
                    Console.WriteLine(portal.ModelName);
                    Console.WriteLine(portal.frontOffset);
                }
            }
        });
    }
}
