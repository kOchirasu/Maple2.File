using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Npc;

// ./data/xml/npc/%02d/%08d.xml
[XmlRoot("ms2")]
public class NpcEnvironmentData {
    [XmlElement] public List<NpcData> environment;
    [XmlElement] public List<EffectDummy> effectdummy;

    internal (NpcData, List<EffectDummy>) Filter(Filter filter) {
        NpcData npcData = environment
            .Where(data => filter.FeatureEnabled(data.feature))
            .FirstOrDefault(data => filter.HasLocale(data.locale));

        return (npcData, effectdummy);
    }
}

public class NpcData {
    [XmlAttribute] public string feature = string.Empty;
    [XmlAttribute] public string locale = string.Empty;

    [XmlElement] public Model model;
    [XmlElement] public Basic basic;
    [XmlElement] public Npc.Stat stat;
    [XmlElement] public Speed speed;
    [XmlElement] public Distance distance;
    [XmlElement] public Crystals crystals;
    [XmlElement] public Npc.Skill skill;
    [XmlElement] public Npc.AdditionalEffect additionalEffect;
    [XmlElement] public Interact interact;
    [XmlElement] public Combat combat; // Ignored by client.
    [XmlElement] public Assist assist;
    [XmlElement] public AiInfo aiInfo;
    [XmlElement] public Collision collision;
    [XmlElement] public NodeCollisions nodeCollisions;
    [XmlElement] public NodeServerCollisions nodeServerCollisions;
    [XmlElement] public Capsule capsule;
    [XmlElement] public ValidBattleCylinder validBattleCylinder;
    [XmlElement] public Dead dead;
    [XmlElement] public Push push;
    [XmlElement] public Exp exp;
    [XmlElement] public Shadow shadow;
    [XmlElement] public Normal normal;
    [XmlElement] public DropItemInfo dropiteminfo;
    [XmlElement] public LookAtTarget lookattarget;
    [XmlElement] public Corpse corpse;
    [XmlElement] public Ride ride; // Ignored by client.
}