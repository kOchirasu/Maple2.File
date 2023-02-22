﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.Pet;
using Maple2.File.Parser.Xml.String;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser;

public class PetParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer petSerializer;
    private readonly XmlSerializer petPropertySerializer;

    public PetParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.nameSerializer = new XmlSerializer(typeof(StringMapping));
        this.petSerializer = new XmlSerializer(typeof(PetDataRoot));
        this.petPropertySerializer = new XmlSerializer(typeof(PetPropertyRoot));
    }

    public IEnumerable<(int Id, string Name, PetData data)> Parse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/petname.xml"));
        var mapping = nameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> petNames = mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("pet/"))) {
            var root = petSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as PetDataRoot;
            Debug.Assert(root != null);

            PetData data = root.pet;
            if (data == null) continue;

            int petId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (petId, petNames.GetValueOrDefault(petId), data);
        }
    }

    public IEnumerable<PetProperty> ParseProperty() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("petproperty.xml"));
        var root = petPropertySerializer.Deserialize(reader) as PetPropertyRoot;
        Debug.Assert(root != null);

        return root.pets;
    }
}
