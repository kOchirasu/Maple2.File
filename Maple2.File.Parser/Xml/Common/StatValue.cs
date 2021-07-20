using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Common {
    [XmlType(Namespace = "Common")]
    public class StatValue {
        [XmlAttribute] public long str;
        [XmlAttribute] public long dex;
        [XmlAttribute("int")] public long @int;
        [XmlAttribute] public long luk;
        [XmlAttribute] public long hp;
        [XmlAttribute] public long hp_rgp;
        [XmlAttribute] public long hp_inv;
        [XmlAttribute] public long sp;
        [XmlAttribute] public long sp_rgp;
        [XmlAttribute] public long sp_inv;
        [XmlAttribute] public long ep;
        [XmlAttribute] public long ep_rgp;
        [XmlAttribute] public long ep_inv;
        [XmlAttribute] public long asp;
        [XmlAttribute] public long msp;
        [XmlAttribute] public long atp;
        [XmlAttribute] public long evp;
        [XmlAttribute] public long cap;
        [XmlAttribute] public long cad;
        [XmlAttribute] public long car;
        [XmlAttribute] public long ndd;
        [XmlAttribute] public long abp;
        [XmlAttribute] public long jmp;
        [XmlAttribute] public long pap;
        [XmlAttribute] public long map;
        [XmlAttribute] public long par;
        [XmlAttribute] public long mar;
        [XmlAttribute] public long wapmin;
        [XmlAttribute] public long wapmax;

        [XmlAttribute] public long dmg;

        //[XmlAttribute] public long dmg;
        [XmlAttribute] public long pen;
        [XmlAttribute] public long rmsp;
        [XmlAttribute] public long bap;
        [XmlAttribute] public long bap_pet;
    }
}
