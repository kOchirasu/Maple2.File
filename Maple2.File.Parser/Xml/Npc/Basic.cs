﻿using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc {
    public partial class Basic {
        [XmlAttribute] public string stringID = string.Empty;
        [XmlAttribute] public int friendly;
        [XmlAttribute] public int npcAttackGroup;
        [XmlAttribute] public int npcDefenseGroup;
        [XmlAttribute] public int kind = 3;
        [XmlAttribute] public string iconName = string.Empty;
        [XmlAttribute] public string minimapIconName = string.Empty;
        [XmlAttribute] public string shopIconName = string.Empty;
        [XmlAttribute] public int shopId;
        [XmlAttribute] public int nametag;
        [XmlAttribute] public int nametagSize = 16;
        [XmlAttribute] public int local;
        [XmlAttribute] public int minimap = 1;
        [XmlAttribute] public int attackDamage;
        [XmlAttribute] public int hpBar;
        [XmlAttribute] public int defenceMaterial;
        [XmlAttribute] public int hitImmune;
        [XmlAttribute] public int abnormalImmune;
        [XmlAttribute] public short level = 1;
        [XmlAttribute("class")] public int @class = 1;
        [XmlAttribute] public int rotationDisabled;
        [XmlAttribute] public int carePathToEnemy = 1;
        [XmlAttribute] public string rankIcon = string.Empty;
        [XmlAttribute] public string npcSoundStart = string.Empty;
        [XmlAttribute] public string npcSoundEnd = string.Empty;
        [XmlAttribute] public string npcSoundCombatStart = string.Empty;
        [XmlAttribute] public string npcSoundCombatEnd = string.Empty;
        [XmlAttribute] public string npcSoundDead = string.Empty;
        [M2dArray] public string[] mainTags = Array.Empty<string>();
        [M2dArray] public string[] subTags = Array.Empty<string>();
        [XmlAttribute] public int maxSpawnCount;
        [XmlAttribute] public int groupSpawnCount;
        [XmlAttribute] public int rareDegree;
        [XmlAttribute] public int difficulty;
        [XmlAttribute] public int talkAni;
        [XmlAttribute] public float damagedColorScale;
        [XmlAttribute] public float damagedVibrateDuration;
        [XmlAttribute] public float damagedVibrateAmp;
        [XmlAttribute] public string portrait = string.Empty;
        [XmlAttribute] public string regenEffect = string.Empty;
        [XmlAttribute] public string deadEffect = string.Empty;
        [XmlAttribute] public string damageEffect = string.Empty;
        [XmlAttribute] public string createEffect = string.Empty;
        [XmlAttribute] public string keepEffect = string.Empty;
        [XmlAttribute] public int skipFrame;
        [XmlAttribute] public float checkCameraDistance;
        [XmlAttribute] public float extraCameraDistance;
        [XmlAttribute] public float bossSoundDistance;
        [XmlAttribute] public float bossSoundEndDistance;
        [XmlAttribute] public int bossNotify;
        [XmlAttribute] public int gender;
        [XmlAttribute] public string illust = string.Empty;
        [XmlAttribute] public int emotionID;
        [XmlAttribute] public bool installNpc;
        [XmlAttribute] public bool locking;
        [M2dArray] public string[] propertyTags = Array.Empty<string>();
        [M2dArray] public string[] raceString = Array.Empty<string>();
        [M2dArray] public string[] eventTags = Array.Empty<string>();

        // Ignored by client.
        [XmlAttribute] public int webFinder;
        [XmlAttribute] public int StopFightingStartHour;
        [XmlAttribute] public int StopFightingEndHour;
        [XmlAttribute] public int StopFightingStartMin;
        [XmlAttribute] public int StopFightingEndMin;
    }
}