﻿using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Xml;
using Maple2.File.IO.Crypto;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.IO.Crypto.Stream;

namespace Maple2.File.IO {
    public class M2dReader {
        private readonly MemoryMappedFile m2dFile;
        public readonly IReadOnlyList<PackFileEntry> Files;

        public M2dReader(string path) {
            m2dFile = MemoryMappedFile.CreateFromFile(path);

            // Create an index from the header file
            using var headerReader = new BinaryReader(System.IO.File.OpenRead(path.Replace(".m2d", ".m2h")));
            var stream = IPackStream.CreateStream(headerReader);

            string fileString =
                Encoding.UTF8.GetString(CryptoManager.DecryptFileString(stream, headerReader.BaseStream));
            stream.FileList.AddRange(PackFileEntry.CreateFileList(fileString));
            stream.FileList.Sort();

            // Load the file allocation table and assign each file header to the entry within the list
            byte[] fileTable = CryptoManager.DecryptFileTable(stream, headerReader.BaseStream);

            using var tableStream = new MemoryStream(fileTable);
            using var reader = new BinaryReader(tableStream);
            stream.InitFileList(reader);

            Files = stream.FileList;
        }

        public XmlReader GetXmlReader(PackFileEntry entry) {
            return XmlReader.Create(new MemoryStream(CryptoManager.DecryptData(entry.FileHeader, m2dFile)));
        }

        public XmlDocument GetXmlDocument(PackFileEntry entry) {
            var document = new XmlDocument();
            byte[] data = CryptoManager.DecryptData(entry.FileHeader, m2dFile);
            try {
                document.Load(new MemoryStream(data));
            } catch {
                string xmlText = Encoding.Default.GetString(data);
                document.LoadXml(xmlText);
            }

            return document;
        }

        public byte[] GetBytes(PackFileEntry entry) {
            return CryptoManager.DecryptData(entry.FileHeader, m2dFile);
        }

        public string GetString(PackFileEntry entry) {
            byte[] data = CryptoManager.DecryptData(entry.FileHeader, m2dFile);
            return Encoding.Default.GetString(data);
        }
    }
}