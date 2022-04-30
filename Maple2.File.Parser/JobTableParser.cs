using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser; 

public class JobTableParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer jobSerializer;

    public JobTableParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.jobSerializer = new XmlSerializer(typeof(JobRoot));
    }

    public IEnumerable<JobTable> Parse() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/job.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = jobSerializer.Deserialize(reader) as JobRoot;
        Debug.Assert(data != null);

        foreach (JobTable job in data.job) {
            yield return job;
        }
    }
}
