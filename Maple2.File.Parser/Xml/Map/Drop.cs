using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Map {
    public class Drop {
        [XmlAttribute] public int maplevel = 1;
        [XmlAttribute] public int droprank = 1;
        [XmlIgnore] public int[] globalDropBoxID = Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("globalDropBoxID")]
        public string _globalDropBoxID {
            get => Serialize.IntCsv(globalDropBoxID);
            set => globalDropBoxID = Deserialize.IntCsv(value);
        }
    }
}