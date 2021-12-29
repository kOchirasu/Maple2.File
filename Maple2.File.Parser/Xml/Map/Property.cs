using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Map; 

public partial class Property {
    [XmlAttribute] public int mapCategoryCode;
    [XmlAttribute] public int revivalreturnid; // mapId if 0
    [XmlAttribute] public int enterreturnid;
    [XmlAttribute] public int capacity;
    [XmlAttribute] public int channelGroupID;
    [XmlAttribute] public int enterAdminLevel;
    [XmlAttribute] public short enterMinLevel;
    [XmlAttribute] public short enterMaxLevel;
    [XmlAttribute] public int massiveEventField;
    [XmlAttribute] public int recoveryFullHP;
    [XmlAttribute] public int continentCode;
    [XmlAttribute] public int regionCode;
    [XmlAttribute] public int useTimeEvent;
    [XmlAttribute] public int homeReturnable = 1;
    [XmlAttribute] public int deathPenalty = 1;
    [XmlAttribute] public int minimapInvisible;
    [XmlAttribute] public int autoRevivalType;
    [XmlAttribute] public int autoRevivalTime;
    [XmlAttribute] public int onlyDarkTomb;
    [XmlAttribute] public int pkMode;
    [XmlAttribute] public int webFinder;
    [XmlAttribute] public int checkFly;
    [XmlAttribute] public int checkClimb = 1;
    [XmlAttribute] public int limitMove;
    [XmlAttribute] public int checkPartyObserve;
    [XmlAttribute] public int doNotRevivalHere;
    [XmlAttribute] public float cubeSkillIntervalTime;
    [XmlAttribute] public int limitContent;
    [XmlAttribute] public bool mapSearch = true;
    [XmlAttribute] public int mapType;
    [XmlAttribute] public int infinityMeratRevival = 1;
    [XmlAttribute] public int bigCity;
    [XmlAttribute] public int exploreType;
    [XmlAttribute] public int tutorialType;
    [XmlAttribute] public int requireQuest;
    [XmlAttribute] public bool minimapPing;
    [XmlAttribute] public bool popupMenu = true;
    [XmlAttribute] public bool gemSystem = true;
    [M2dArray] public int[] skillUseDisable = Array.Empty<int>();
    [M2dArray] public int[] enteranceBuffIDs = Array.Empty<int>();
    [M2dArray] public int[] enteranceBuffLevels = Array.Empty<int>();
    [M2dArray] public string[] propertyTags = Array.Empty<string>();

    // Ignored by client.
    [XmlAttribute] public int additionalUseDisable;
    [XmlAttribute] public int ignoreFindParty;
}