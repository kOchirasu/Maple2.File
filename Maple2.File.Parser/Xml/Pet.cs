using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Xml.Pet;

namespace Maple2.File.Parser.Xml {
    // ./data/xml/table/petproperty.xml
    [XmlRoot("ms2")]
    public class PetPropertyRoot {
        [XmlElement] public List<PetProperty> pets;
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

        [XmlElement] public Pet.Skill skill;
        [XmlElement] public Distance distance;
        [XmlElement] public Time time;
    }
}