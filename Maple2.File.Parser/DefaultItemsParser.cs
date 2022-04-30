using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser; 

public class DefaultItemsParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer defaultItemsSerializer;

    public DefaultItemsParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.defaultItemsSerializer = new XmlSerializer(typeof(DefaultItems));
    }

    public IEnumerable<(int JobCode, string Slot, IList<DefaultItems.Item>)> Parse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("defaultitems.xml"));
        var data = defaultItemsSerializer.Deserialize(reader) as DefaultItems;
        Debug.Assert(data != null);

        foreach (DefaultItems.Key key in data.key) {
            foreach (DefaultItems.Slot slot in key.slot) {
                yield return (key.jobCode, slot.name, slot.item);
            }
        }
    }
}
