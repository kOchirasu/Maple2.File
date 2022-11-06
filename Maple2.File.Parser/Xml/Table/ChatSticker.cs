using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/chatemoticon.xml
[XmlRoot("ms2")]
public class ChatStickerRoot {
    [XmlElement] public List<ChatSticker> sticker;
}

public partial class ChatSticker : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int group_id;
    [XmlAttribute] public int category_id;
}
