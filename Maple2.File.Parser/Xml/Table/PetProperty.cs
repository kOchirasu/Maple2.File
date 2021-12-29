using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/petproperty.xml
[XmlRoot("ms2")]
public class PetPropertyRoot {
    [XmlElement] public List<PetProperty> pets;

    internal List<PetProperty> Filter(Filter filter) {
        return pets
            .Where(pet => filter.FeatureEnabled(pet.feature))
            .GroupBy(pet => pet.code)
            .FirstByLocale(filter, pet => pet.locale)
            .ToList();
    }
}

public partial class PetProperty {
    [XmlAttribute] public string feature = string.Empty;
    [XmlAttribute] public string locale = string.Empty;

    [XmlAttribute] public int type;
    [XmlAttribute] public int code;
    [XmlAttribute] public int slotNum;
    [XmlAttribute] public int collectGroupId;
    [XmlAttribute] public bool isCollectPreview;
    [XmlAttribute] public int tamingGroupID;
    [XmlAttribute] public bool enablePetExtraction;
    [XmlAttribute] public int npcID;
    [M2dArray] public int[] itemIDs = Array.Empty<int>();
    [M2dArray] public string[] tamingAiPresets = Array.Empty<string>();
    [XmlAttribute] public int passiveSkillId;
    [XmlAttribute] public short passiveSkillLevel;
    [XmlAttribute] public float warpDistance;
    [XmlAttribute] public float traceDistance;
    [XmlAttribute] public float battleTraceDistance;
    [XmlAttribute] public float nameTagOffsetY;
    [XmlAttribute] public short optionLevel;
    [XmlAttribute] public float constantOptionFactor;
    [M2dArray] public int[] additionalEffectID;
    [M2dArray] public short[] additionalEffectLevel;

    // useless data
    [XmlElement] public Skill skill;

    public class Skill {
        [XmlAttribute] public int id;
        [XmlAttribute] public short level;
    }
}

// ./data/xml/pet/%08d.xml
[XmlRoot("ms2")]
public class PetDataRoot {
    [XmlElement] public PetData pet;
}

public class PetData {
    [XmlAttribute] public int code;
    [XmlAttribute] public int slotNum;

    [XmlElement] public Skill skill;
    [XmlElement] public Distance distance;
    [XmlElement] public Time time;

    public class Skill {
        [XmlAttribute] public int id;
        [XmlAttribute] public short level = 1;
    }

    public class Distance {
        [XmlAttribute] public float pick;
        [XmlAttribute] public float warp;
        [XmlAttribute] public float trace;
        [XmlAttribute] public float battleTrace;
    }

    public class Time {
        [XmlAttribute] public int idle;
        [XmlAttribute] public int bore;
        [XmlAttribute] public int summonCast;
        [XmlAttribute] public int tired;
        [XmlAttribute] public int skill;
        [XmlAttribute] public int PetSlotNum;
    }
}