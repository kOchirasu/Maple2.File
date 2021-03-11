using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml {
    [XmlRoot("ugcmap")]
    public partial class UgcMap {
        [M2dArray] public int[] baseCubePoint3 = {0, 0, 0};
        [M2dArray(Delimiter = 'x')] public int[] indoorSizeType = {0, 0, 0};

        [XmlElement] public List<Cube> cube;

        public partial class Cube {
            [XmlAttribute] public int itemID;
            [M2dArray] public int[] offsetCubePoint3 = {0, 0, 0};
            [XmlAttribute] public int rotation;
            [XmlAttribute] public int wallDir;
        }
    }
}