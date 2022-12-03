﻿using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class TableParserTest {
    [TestMethod]
    public void TestColorPaletteParser() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseColorPalette()) {
            continue;
        }

        foreach ((_, _) in parser.ParseColorPaletteAchieve()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseScroll() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseEnchantScroll()) {
            continue;
        }
        foreach ((_, _) in parser.ParseItemRemakeScroll()) {
            continue;
        }
        foreach ((_, _) in parser.ParseItemRepackingScroll()) {
            continue;
        }
        foreach ((_, _) in parser.ParseItemSocketScroll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBankType() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseBankType()) {
            continue;
        }
    }

    [TestMethod]
    public void TestChatSticker() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseChatSticker()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseDefaultItems() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _, _) in parser.ParseDefaultItems()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseDungeonRoom() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseDungeonRoom()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFish() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseFish()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishHabitat() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseFishHabitat()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishingRod() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseFishingRod()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishingSpot() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseFishingSpot()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildBuff() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildBuff()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildContribution() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildContribution()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildEvent() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildEvent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildExp() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildEvent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildHouse() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildHouse()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildNpc() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildNpc()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildProperty() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildProperty()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInstrumentCategoryInfo() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseInstrumentCategoryInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInstrumentInfo() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseInstrumentInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInteractObjectInfo() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseInteractObject()) {
            continue;
        }
        foreach ((_, _) in parser.ParseInteractObjectMastery()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemBreakIngredient() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemBreakIngredient()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemExchangeScroll() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemExchangeScroll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestItemExtraction() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemExtraction()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemGemstoneUpgrade() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemGemstoneUpgrade()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemLapenshardUpgrade() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemLapenshardUpgrade()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemSocket() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemSocket()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseJobTable() {
        var parser = new TableParser(TestUtils.XmlReader);

        Dictionary<int, List<JobTable>> results = parser.ParseJobTable()
            .GroupBy(result => result.code)
            .ToDictionary(group => group.Key, group => group.ToList());

        var expected = new Dictionary<int, (string, int)> {
            {1, ("", 1)},
            {10, ("JobChange_02", 2)},
            {20, ("JobChange_02", 1)},
            {30, ("JobChange_02", 1)},
            {40, ("JobChange_02", 2)},
            {50, ("JobChange_02", 1)},
            {60, ("JobChange_02", 1)},
            {70, ("JobChange_02", 2)},
            {80, ("JobChange_02", 2)},
            {90, ("JobChange_02", 1)},
            {100, ("JobChange_02", 1)},
            {110, ("JobChange_02", 1)},
        };
        foreach ((int jobCode, (string feature, int itemCount)) in expected) {
            Assert.IsTrue(results.TryGetValue(jobCode, out List<JobTable>? job));
            Assert.IsNotNull(job);
            // Ensure that FeatureLocale was filtered properly
            Assert.AreEqual(1, job.Count);
            Assert.AreEqual(job[0].Feature, feature);
            // Ensure that some value was parsed
            Assert.IsTrue(job[0].skills.skill.Count > 0);
            Assert.IsTrue(job[0].learn.Count > 0);
            // Ensure the right amount of items are parsed
            Assert.AreEqual(job[0].startInvenItem.item.Count, itemCount);
            Assert.AreEqual(job[0].reward.item.Count, itemCount);
        }
    }

    [TestMethod]
    public void TestParseMagicPath() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMagicPath()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseMapSpawnTag() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMapSpawnTag()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryRecipe() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMasteryRecipe()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryReward() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMasteryReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePetTable() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParsePetExp()) {
            continue;
        }
        foreach ((_, _) in parser.ParsePetProperty()) {
            continue;
        }
        foreach ((_, _) in parser.ParsePetSpawnInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubEffect() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParsePremiumClubEffect()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubItem() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParsePremiumClubItem()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubPackage() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParsePremiumClubPackage()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseSetItemInfo() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseSetItemInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseSetItemOption() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseSetItemOption()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseTitleTag() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseTitleTag()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDrop() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemDrop()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropCharge() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemDropCharge()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropEvent() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemDropEvent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropEventNpc() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemDropEventNpc()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropNewGacha() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemDropNewGacha()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropPet() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemDropPet()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropQuestObj() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemDropQuestObj()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropQuestMob() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemDropQuestMob()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropGacha() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemDropGacha()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropGearBox() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemGearBox()) {
            continue;
        }
    }
}
