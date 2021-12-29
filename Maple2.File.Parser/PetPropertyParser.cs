using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser;

public class PetPropertyParser {
    private readonly M2dReader xmlReader;
    private readonly Filter filter;
    private readonly XmlSerializer petSerializer;

    public PetPropertyParser(M2dReader xmlReader, Filter filter) {
        this.xmlReader = xmlReader;
        this.filter = filter;
        this.petSerializer = new XmlSerializer(typeof(PetPropertyRoot));
    }

    public IEnumerable<PetProperty> Parse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("petproperty.xml"));
        var root = petSerializer.Deserialize(reader) as PetPropertyRoot;
        Debug.Assert(root != null);

        return root.Filter(filter);
    }
}
