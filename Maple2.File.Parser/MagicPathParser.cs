using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser;

public class MagicPathParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer magicSerializer;

    public MagicPathParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.magicSerializer = new XmlSerializer(typeof(MagicPath));
    }

    public IEnumerable<MagicPath> Parse() {
        string sanitized = Sanitizer.SanitizeMagicPath(xmlReader.GetString(xmlReader.GetEntry("magicpath.xml")));
        var data = magicSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as MagicPath;
        Debug.Assert(data != null);

        yield return data;
    }
}
