using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class FinalStatusProperty {
        [XmlElement] public FinalStat Stat;

        // Ignored by client.
        [XmlAttribute] public string value = string.Empty;
        [XmlAttribute] public string rate = string.Empty;
    }

    public class FinalStat {
        [XmlAttribute] public long finalstrvalue;
        [XmlAttribute] public long finaldexvalue;
        [XmlAttribute] public long finalintvalue;
        [XmlAttribute] public long finallukvalue;
        [XmlAttribute] public long finalhpvalue;
        [XmlAttribute] public long finalhp_rgpvalue;
        [XmlAttribute] public long finalhp_invvalue;
        [XmlAttribute] public long finalspvalue;
        [XmlAttribute] public long finalsp_rgpvalue;
        [XmlAttribute] public long finalsp_invvalue;
        [XmlAttribute] public long finalepvalue;
        [XmlAttribute] public long finalep_rgpvalue;
        [XmlAttribute] public long finalep_invvalue;
        [XmlAttribute] public long finalaspvalue;
        [XmlAttribute] public long finalmspvalue;
        [XmlAttribute] public long finalatpvalue;
        [XmlAttribute] public long finalevpvalue;
        [XmlAttribute] public long finalcapvalue;
        [XmlAttribute] public long finalcadvalue;
        [XmlAttribute] public long finalcarvalue;
        [XmlAttribute] public long finalnddvalue;
        [XmlAttribute] public long finalabpvalue;
        [XmlAttribute] public long finaljmpvalue;
        [XmlAttribute] public long finalpapvalue;
        [XmlAttribute] public long finalmapvalue;
        [XmlAttribute] public long finalparvalue;
        [XmlAttribute] public long finalmarvalue;
        [XmlAttribute] public long finalwapminvalue;
        [XmlAttribute] public long finalwapmaxvalue;
        [XmlAttribute] public long finaldmgvalue;
        //[XmlAttribute] public long finaldmgvalue;
        [XmlAttribute] public long finalpenvalue;
        [XmlAttribute] public long finalrmspvalue;
        [XmlAttribute] public long finalbapvalue;
        [XmlAttribute] public long finalbap_petvalue;

        [XmlAttribute] public float finalstrrate;
        [XmlAttribute] public float finaldexrate;
        [XmlAttribute] public float finalintrate;
        [XmlAttribute] public float finallukrate;
        [XmlAttribute] public float finalhprate;
        [XmlAttribute] public float finalhp_rgprate;
        [XmlAttribute] public float finalhp_invrate;
        [XmlAttribute] public float finalsprate;
        [XmlAttribute] public float finalsp_rgprate;
        [XmlAttribute] public float finalsp_invrate;
        [XmlAttribute] public float finaleprate;
        [XmlAttribute] public float finalep_rgprate;
        [XmlAttribute] public float finalep_invrate;
        [XmlAttribute] public float finalasprate;
        [XmlAttribute] public float finalmsprate;
        [XmlAttribute] public float finalatprate;
        [XmlAttribute] public float finalevprate;
        [XmlAttribute] public float finalcaprate;
        [XmlAttribute] public float finalcadrate;
        [XmlAttribute] public float finalcarrate;
        [XmlAttribute] public float finalnddrate;
        [XmlAttribute] public float finalabprate;
        [XmlAttribute] public float finaljmprate;
        [XmlAttribute] public float finalpaprate;
        [XmlAttribute] public float finalmaprate;
        [XmlAttribute] public float finalparrate;
        [XmlAttribute] public float finalmarrate;
        [XmlAttribute] public float finalwapminrate;
        [XmlAttribute] public float finalwapmaxrate;
        [XmlAttribute] public float finaldmgrate;
        //[XmlAttribute] public float finaldmgrate;
        [XmlAttribute] public float finalpenrate;
        [XmlAttribute] public float finalrmsprate;
        [XmlAttribute] public float finalbaprate;
        [XmlAttribute] public float finalbap_petrate;
    }
}