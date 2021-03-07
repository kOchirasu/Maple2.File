using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Item;

// ./data/xml/item/%01d/%02d/%08u.xml
namespace Maple2.File.Parser.Xml {
    [XmlRoot("ms2")]
    public class ItemEnvironmentData {
        [XmlElement] public List<ItemData> environment;
    }

    public class ItemData {
        [XmlAttribute] public string feature = string.Empty;
        [XmlAttribute] public string locale = string.Empty;

        [XmlElement] public Basic basic;
        [XmlElement] public Slots slots;
        [XmlElement] public Customize customize;
        [XmlElement] public Mutation mutation;
        [XmlElement] public Cutting cutting;
        [XmlElement] public Install install;
        [XmlElement] public Property property;
        [XmlElement] public Material material;
        [XmlElement] public Life life;
        [XmlElement] public Limit limit;
        [XmlElement] public Item.Skill skill;
        [XmlElement] public Item.Skill objectWeaponSkill;
        [XmlElement] public Title title;
        [XmlElement] public Drop drop;
        [XmlElement] public UCC ucc;
        [XmlElement] public Effect effect;
        [XmlElement] public Fusion fusion;
        [XmlElement] public Pet pet;
        [XmlElement] public Ride ride;
        [XmlElement] public Badge gem;
        [XmlElement] public Item.AdditionalEffect AdditionalEffect;
        [XmlElement] public Function function;
        [XmlElement] public Tool tool;
        [XmlElement] public Option option;
        [XmlElement] public Maid maid;
        [XmlElement] public PCBang PCBang;
        [XmlElement] public MusicScore MusicScore;
        [XmlElement] public Housing housing;
        [XmlElement] public Shop Shop;
    }
}