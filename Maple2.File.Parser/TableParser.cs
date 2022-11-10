using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser;

public class TableParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer chatStickerSerializer;
    private readonly XmlSerializer defaultItemsSerializer;
    private readonly XmlSerializer dungeonRoomSerializer;
    private readonly XmlSerializer fishSerializer;
    private readonly XmlSerializer fishHabitatSerializer;
    private readonly XmlSerializer fishingRodSerializer;
    private readonly XmlSerializer fishingSpotSerializer;
    private readonly XmlSerializer guildBuffSerializer;
    private readonly XmlSerializer guildContributionSerializer;
    private readonly XmlSerializer guildEventSerializer;
    private readonly XmlSerializer guildExpSerializer;
    private readonly XmlSerializer guildHouseSerializer;
    private readonly XmlSerializer guildNpcSerializer;
    private readonly XmlSerializer guildPropertySerializer;
    private readonly XmlSerializer instrumentCategoryInfoSerializer;
    private readonly XmlSerializer instrumentInfoSerializer;
    private readonly XmlSerializer interactObjectSerializer;
    private readonly XmlSerializer itemBreakIngredientSerializer;
    private readonly XmlSerializer itemExchangeScrollSerializer;
    private readonly XmlSerializer itemExtractionSerializer;
    private readonly XmlSerializer itemGemstoneUpgradeSerializer;
    private readonly XmlSerializer itemLapenshardUpgradeSerializer;
    private readonly XmlSerializer jobSerializer;
    private readonly XmlSerializer magicPathSerializer;
    private readonly XmlSerializer mapSpawnTagSerializer;
    private readonly XmlSerializer masteryRecipeSerializer;
    private readonly XmlSerializer masteryRewardSerializer;
    private readonly XmlSerializer paletteSerializer;
    private readonly XmlSerializer petSpawnInfoSerializer;
    private readonly XmlSerializer premiumClubEffectSerializer;
    private readonly XmlSerializer premiumClubItemSerializer;
    private readonly XmlSerializer premiumClubPackageSerializer;
    private readonly XmlSerializer setItemInfoSerializer;
    private readonly XmlSerializer setItemOptionSerializer;

    public TableParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.chatStickerSerializer = new XmlSerializer(typeof(ChatStickerRoot));
        this.defaultItemsSerializer = new XmlSerializer(typeof(DefaultItems));
        this.dungeonRoomSerializer = new XmlSerializer(typeof(DungeonRoomRoot));
        this.fishSerializer = new XmlSerializer(typeof(FishRoot));
        this.fishHabitatSerializer = new XmlSerializer(typeof(FishHabitatRoot));
        this.fishingRodSerializer = new XmlSerializer(typeof(FishingRodRoot));
        this.fishingSpotSerializer = new XmlSerializer(typeof(FishingSpotRoot));
        this.guildBuffSerializer = new XmlSerializer(typeof(GuildBuffRoot));
        this.guildContributionSerializer = new XmlSerializer(typeof(GuildContributionRoot));
        this.guildEventSerializer = new XmlSerializer(typeof(GuildEventRoot));
        this.guildExpSerializer = new XmlSerializer(typeof(GuildExpRoot));
        this.guildHouseSerializer = new XmlSerializer(typeof(GuildHouseRoot));
        this.guildNpcSerializer = new XmlSerializer(typeof(GuildNpcRoot));
        this.guildPropertySerializer = new XmlSerializer(typeof(GuildPropertyRoot));
        this.instrumentCategoryInfoSerializer = new XmlSerializer(typeof(InstrumentCategoryInfoRoot));
        this.instrumentInfoSerializer = new XmlSerializer(typeof(InstrumentInfoRoot));
        this.interactObjectSerializer = new XmlSerializer(typeof(InteractObjectRoot));
        this.itemBreakIngredientSerializer = new XmlSerializer(typeof(ItemBreakIngredientRoot));
        this.itemExchangeScrollSerializer = new XmlSerializer(typeof(ItemExchangeScrollRoot));
        this.itemExtractionSerializer = new XmlSerializer(typeof(ItemExtractionRoot));
        this.itemGemstoneUpgradeSerializer = new XmlSerializer(typeof(ItemGemstoneUpgradeRoot));
        this.itemLapenshardUpgradeSerializer = new XmlSerializer(typeof(ItemLapenshardUpgradeRoot));
        this.jobSerializer = new XmlSerializer(typeof(JobRoot));
        this.magicPathSerializer = new XmlSerializer(typeof(MagicPath));
        this.mapSpawnTagSerializer = new XmlSerializer(typeof(MapSpawnTag));
        this.masteryRecipeSerializer = new XmlSerializer(typeof(MasteryRecipeRoot));
        this.masteryRewardSerializer = new XmlSerializer(typeof(MasteryRewardRoot));
        this.paletteSerializer = new XmlSerializer(typeof(ColorPaletteRoot));
        this.petSpawnInfoSerializer = new XmlSerializer(typeof(PetSpawnInfoRoot));
        this.premiumClubEffectSerializer = new XmlSerializer(typeof(PremiumClubEffectRoot));
        this.premiumClubItemSerializer = new XmlSerializer(typeof(PremiumClubItemRoot));
        this.premiumClubPackageSerializer = new XmlSerializer(typeof(PremiumClubPackageRoot));
        this.setItemInfoSerializer = new XmlSerializer(typeof(SetItemInfoRoot));
        this.setItemOptionSerializer = new XmlSerializer(typeof(SetItemOptionRoot));
    }

    public IEnumerable<(int Id, ChatSticker ChatSticker)> ParseChatSticker() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/chatemoticon.xml"));
        var data = chatStickerSerializer.Deserialize(reader) as ChatStickerRoot;
        Debug.Assert(data != null);

        foreach (ChatSticker sticker in data.chatEmoticon) {
            yield return (sticker.id, sticker);
        }
    }

    public IEnumerable<(int Id, ColorPalette Palette)> ParseColorPalette() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/colorpalette.xml"));
        var data = paletteSerializer.Deserialize(reader) as ColorPaletteRoot;
        Debug.Assert(data != null);

        foreach (ColorPalette palette in data.color) {
            yield return (palette.id, palette);
        }
    }

    public IEnumerable<(int Id, ColorPalette Palette)> ParseColorPaletteAchieve() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/na/colorpalette_achieve.xml"));
        var data = paletteSerializer.Deserialize(reader) as ColorPaletteRoot;
        Debug.Assert(data != null);

        foreach (ColorPalette palette in data.color) {
            yield return (palette.id, palette);
        }
    }

    public IEnumerable<(int JobCode, string Slot, IList<DefaultItems.Item> Items)> ParseDefaultItems() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/defaultitems.xml"));
        var data = defaultItemsSerializer.Deserialize(reader) as DefaultItems;
        Debug.Assert(data != null);

        foreach (DefaultItems.Key key in data.key) {
            foreach (DefaultItems.Slot slot in key.slot) {
                yield return (key.jobCode, slot.name, slot.item);
            }
        }
    }

    public IEnumerable<(int Id, DungeonRoom Item)> ParseDungeonRoom() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/na/dungeonroom.xml"));
        var data = dungeonRoomSerializer.Deserialize(reader) as DungeonRoomRoot;
        Debug.Assert(data != null);

        foreach (DungeonRoom dungeon in data.dungeonRoom) {
            yield return (dungeon.dungeonRoomID, dungeon);
        }
    }

    public IEnumerable<(int Id, Fish Fish)> ParseFish() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/fish.xml"));
        var data = fishSerializer.Deserialize(reader) as FishRoot;
        Debug.Assert(data != null);

        foreach (Fish fish in data.fish) {
            yield return (fish.id, fish);
        }
    }

    public IEnumerable<(int Id, FishHabitat Habitat)> ParseFishHabitat() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/fishhabitat.xml"));
        var data = fishHabitatSerializer.Deserialize(reader) as FishHabitatRoot;
        Debug.Assert(data != null);

        foreach (FishHabitat habitat in data.fish) {
            yield return (habitat.id, habitat);
        }
    }

    public IEnumerable<(int Id, FishingRod Rod)> ParseFishingRod() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/fishingrod.xml"));
        var data = fishingRodSerializer.Deserialize(reader) as FishingRodRoot;
        Debug.Assert(data != null);

        foreach (FishingRod rod in data.rod) {
            yield return (rod.rodCode, rod);
        }
    }

    public IEnumerable<(int Id, FishingSpot Spot)> ParseFishingSpot() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/fishingspot.xml"));
        var data = fishingSpotSerializer.Deserialize(reader) as FishingSpotRoot;
        Debug.Assert(data != null);

        foreach (FishingSpot spot in data.spot) {
            yield return (spot.id, spot);
        }
    }

    public IEnumerable<(int Id, IEnumerable<GuildBuff> Buff)> ParseGuildBuff() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildbuff.xml"));
        var data = guildBuffSerializer.Deserialize(reader) as GuildBuffRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, GuildBuff> group in data.guildBuff.GroupBy(guildBuff => guildBuff.id)) {
            yield return (group.Key, group);
        }
    }

    public IEnumerable<(GuildContributionType Id, GuildContribution Item)> ParseGuildContribution() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildcontribution.xml"));
        var data = guildContributionSerializer.Deserialize(reader) as GuildContributionRoot;
        Debug.Assert(data != null);

        foreach (GuildContribution contribution in data.contribution) {
            yield return (contribution.type, contribution);
        }
    }

    public IEnumerable<(int Id, GuildEvent Item)> ParseGuildEvent() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildcontribution.xml"));
        var data = guildEventSerializer.Deserialize(reader) as GuildEventRoot;
        Debug.Assert(data != null);

        foreach (GuildEvent @event in data.guildEvent) {
            yield return (@event.id, @event);
        }
    }

    public IEnumerable<(int Id, GuildExp Item)> ParseGuildExp() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildexp.xml"));
        var data = guildExpSerializer.Deserialize(reader) as GuildExpRoot;
        Debug.Assert(data != null);

        foreach (GuildExp exp in data.guildExp) {
            yield return (exp.level, exp);
        }
    }

    public IEnumerable<(int Id, IEnumerable<GuildHouse> Item)> ParseGuildHouse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildhouse.xml"));
        var data = guildHouseSerializer.Deserialize(reader) as GuildHouseRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, GuildHouse> group in data.guildHouse.GroupBy(guildHouse => guildHouse.level)) {
            yield return (group.Key, group);
        }
    }

    public IEnumerable<(GuildNpcType Type, IEnumerable<GuildNpc> Item)> ParseGuildNpc() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildnpc.xml"));
        var data = guildNpcSerializer.Deserialize(reader) as GuildNpcRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<GuildNpcType, GuildNpc> group in data.npc.GroupBy(guildNpc => guildNpc.type)) {
            yield return (group.Key, group);
        }
    }

    public IEnumerable<(int Id, GuildProperty Item)> ParseGuildProperty() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildproperty.xml"));
        var data = guildPropertySerializer.Deserialize(reader) as GuildPropertyRoot;
        Debug.Assert(data != null);

        foreach (GuildProperty property in data.property) {
            yield return (property.level, property);
        }
    }

    public IEnumerable<(int Id, InstrumentCategoryInfo Info)> ParseInstrumentCategoryInfo() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/instrumentcategoryinfo.xml"));
        var data = instrumentCategoryInfoSerializer.Deserialize(reader) as InstrumentCategoryInfoRoot;
        Debug.Assert(data != null);

        foreach (InstrumentCategoryInfo instrument in data.category) {
            yield return (instrument.id, instrument);
        }
    }

    public IEnumerable<(int Id, InstrumentInfo Info)> ParseInstrumentInfo() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/instrumentinfo.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = instrumentInfoSerializer.Deserialize(reader) as InstrumentInfoRoot;
        Debug.Assert(data != null);

        foreach (InstrumentInfo instrument in data.instrument) {
            yield return (instrument.id, instrument);
        }
    }

    public IEnumerable<(int Id, InteractObject Info)> ParseInteractObject() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/interactobject.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = interactObjectSerializer.Deserialize(reader) as InteractObjectRoot;
        Debug.Assert(data != null);

        foreach (InteractObject interact in data.interact) {
            yield return (interact.id, interact);
        }
    }

    public IEnumerable<(int Id, InteractObject Info)> ParseInteractObjectMastery() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/interactobject_mastery.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = interactObjectSerializer.Deserialize(reader) as InteractObjectRoot;
        Debug.Assert(data != null);

        foreach (InteractObject interact in data.interact) {
            yield return (interact.id, interact);
        }
    }

    public IEnumerable<(int ItemId, ItemBreakIngredient Item)> ParseItemBreakIngredient() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/itembreakingredient.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = itemBreakIngredientSerializer.Deserialize(reader) as ItemBreakIngredientRoot;
        Debug.Assert(data != null);

        foreach (ItemBreakIngredient item in data.item) {
            yield return (item.ItemID, item);
        }
    }

    public IEnumerable<(int ExchangeId, ItemExchangeScroll ScrollExchange)> ParseItemExchangeScroll() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/itemexchangescrolltable.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = itemExchangeScrollSerializer.Deserialize(reader) as ItemExchangeScrollRoot;
        Debug.Assert(data != null);

        foreach (ItemExchangeScroll item in data.exchange) {
            yield return (item.id, item);
        }
    }

    public IEnumerable<(int Id, ItemExtraction Extraction)> ParseItemExtraction() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/itemextraction.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = itemExtractionSerializer.Deserialize(reader) as ItemExtractionRoot;
        Debug.Assert(data != null);

        foreach (ItemExtraction item in data.key) {
            yield return (item.TargetItemID, item);
        }
    }

    public IEnumerable<(int ItemId, ItemGemstoneUpgrade Item)> ParseItemGemstoneUpgrade() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/itemgemstoneupgrade.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = itemGemstoneUpgradeSerializer.Deserialize(reader) as ItemGemstoneUpgradeRoot;
        Debug.Assert(data != null);

        foreach (ItemGemstoneUpgrade key in data.key) {
            yield return (key.ItemId, key);
        }
    }

    public IEnumerable<(int ItemId, ItemLapenshardUpgrade Item)> ParseItemLapenshardUpgrade() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/itemlapenshardupgrade.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = itemLapenshardUpgradeSerializer.Deserialize(reader) as ItemLapenshardUpgradeRoot;
        Debug.Assert(data != null);

        foreach (ItemLapenshardUpgrade key in data.key) {
            yield return (key.ItemId, key);
        }
    }

    public IEnumerable<JobTable> ParseJobTable() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/job.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = jobSerializer.Deserialize(reader) as JobRoot;
        Debug.Assert(data != null);

        foreach (JobTable job in data.job) {
            yield return job;
        }
    }

    public IEnumerable<(long Id, MagicType Type)> ParseMagicPath() {
        string sanitized = Sanitizer.SanitizeMagicPath(xmlReader.GetString(xmlReader.GetEntry("table/magicpath.xml")));
        var data = magicPathSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as MagicPath;
        Debug.Assert(data != null);

        foreach (MagicType type in data.type) {
            yield return (type.id, type);
        }
    }

    public IEnumerable<(int MapId, IEnumerable<MapSpawnTag.Region> Region)> ParseMapSpawnTag() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/mapspawntag.xml")));
        var data = mapSpawnTagSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as MapSpawnTag;
        Debug.Assert(data != null);

        foreach (IGrouping<int, MapSpawnTag.Region> group in data.region.GroupBy(region => region.mapCode)) {
            yield return (group.Key, group);
        }
    }

    public IEnumerable<(long Id, MasteryRecipe Recipe)> ParseMasteryRecipe() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/masteryreceipe.xml")));
        var data = masteryRecipeSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as MasteryRecipeRoot;
        Debug.Assert(data != null);

        foreach (MasteryRecipe recipe in data.receipe) {
            yield return (recipe.id, recipe);
        }
    }

    public IEnumerable<(MasteryType Type, MasteryReward Reward)> ParseMasteryReward() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/mastery.xml")));
        var data = masteryRewardSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as MasteryRewardRoot;
        Debug.Assert(data != null);

        foreach (MasteryReward reward in data.mastery) {
            yield return (reward.type, reward);
        }
    }

    public IEnumerable<(int FieldId, IEnumerable<PetSpawnInfo> Info)> ParsePetSpawnInfo() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/petspawninfo.xml"));
        var data = petSpawnInfoSerializer.Deserialize(reader) as PetSpawnInfoRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, PetSpawnInfo> group in data.SpawnInfo.GroupBy(spawnInfo => spawnInfo.fieldID)) {
            yield return (group.Key, group);
        }
    }

    public IEnumerable<(int Id, PremiumClubEffect Item)> ParsePremiumClubEffect() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/vipbenefiteffecttable.xml")));
        var data = premiumClubEffectSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as PremiumClubEffectRoot;
        Debug.Assert(data != null);

        foreach (PremiumClubEffect effect in data.benefit) {
            yield return (effect.effectID, effect);
        }
    }

    public IEnumerable<(int Id, PremiumClubItem Item)> ParsePremiumClubItem() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/vipbenefititemtable.xml")));
        var data = premiumClubItemSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as PremiumClubItemRoot;
        Debug.Assert(data != null);

        foreach (PremiumClubItem item in data.benefit) {
            yield return (item.id, item);
        }
    }

    public IEnumerable<(int Id, PremiumClubPackage Package)> ParsePremiumClubPackage() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/vipgoodstable.xml")));
        var data = premiumClubPackageSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as PremiumClubPackageRoot;
        Debug.Assert(data != null);

        foreach (PremiumClubPackage package in data.goods) {
            yield return (package.id, package);
        }
    }

    public IEnumerable<(int Id, SetItemInfo Info)> ParseSetItemInfo() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/setiteminfo.xml")));
        var data = setItemInfoSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as SetItemInfoRoot;
        Debug.Assert(data != null);

        foreach (SetItemInfo info in data.set) {
            yield return (info.id, info);
        }
    }

    public IEnumerable<(int Id, SetItemOption Option)> ParseSetItemOption() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/setitemoption.xml"));
        var data = setItemOptionSerializer.Deserialize(reader) as SetItemOptionRoot;
        Debug.Assert(data != null);

        foreach (SetItemOption option in data.option) {
            yield return (option.id, option);
        }
    }
}
