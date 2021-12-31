using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// TODO: Validate with IDA against client.
[XmlRoot("ms2")]
public class JobRoot {
    [XmlElement] public List<Job> job;
}

public partial class Job {
    [XmlAttribute] public int code = 1;
    [XmlAttribute] public int characterBGM;
    [M2dArray] public string[] defaultWeaponSlot = Array.Empty<string>();
    [M2dArray] public int[] tutorialSkipField = Array.Empty<int>();
    [XmlAttribute] public int tutorialSkipItem;
    [XmlAttribute] public int tutorialSaveID = -1;
    [M2dArray] public int[] tutorialClearOpenMaps = Array.Empty<int>();
    [M2dArray] public int[] tutorialClearOpenTaxis = Array.Empty<int>();
    [XmlAttribute] public int startField; // default = 524289?

    [XmlElement] public List<CharacterVoice> characterVoice;
    [XmlElement] public StartInvenItem startInvenItem;
    [XmlElement] public Reward reward;
    [XmlElement] public Skills skills;
    [XmlElement] public Learn learn;
}

public partial class CharacterVoice : IFeatureLocale {
    [XmlAttribute] public string value;
}

public partial class StartInvenItem {
    [XmlElement] public List<Item> item;

    public partial class Item : IFeatureLocale {
        [XmlAttribute] public int itemID;
        [XmlAttribute] public int grade;
        [XmlAttribute] public int count;
    }
}

public partial class Reward {
    [XmlElement] public List<Item> item;

    public partial class Item : IFeatureLocale{
        [XmlAttribute] public int itemID;
        [XmlAttribute] public int grade;
        [XmlAttribute] public string slotHint;
    }
}

public partial class Skills {
    [XmlElement] public List<Skill> skill;

    public partial class Skill : IFeatureLocale {
        [XmlAttribute] public int main;
        [XmlAttribute] public int subJobCode;
        [M2dArray] public int[] sub = Array.Empty<int>();
        [M2dArray] public int[] uiPosition = Array.Empty<int>(); // TODO: trim space?
        [XmlAttribute] public bool uiHighlight;
        [XmlAttribute] public short maxLevel;
        [XmlAttribute] public int quickSlotPriority;
    }
}

public partial class Learn {
    [XmlAttribute] public short level;

    [XmlElement] public List<Skill> skill;

    public partial class Skill : IFeatureLocale {
        [XmlAttribute] public int id;
    }
}
