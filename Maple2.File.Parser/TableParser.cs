using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser;

public class TableParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer paletteSerializer;
    private readonly XmlSerializer defaultItemsSerializer;
    private readonly XmlSerializer dungeonRoomSerializer;
    private readonly XmlSerializer itemBreakIngredientSerializer;
    private readonly XmlSerializer itemGemstoneUpgradeSerializer;
    private readonly XmlSerializer itemLapenshardUpgradeSerializer;
    private readonly XmlSerializer jobSerializer;
    private readonly XmlSerializer setItemOptionSerializer;

    public TableParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.paletteSerializer = new XmlSerializer(typeof(ColorPaletteRoot));
        this.defaultItemsSerializer = new XmlSerializer(typeof(DefaultItems));
        this.dungeonRoomSerializer = new XmlSerializer(typeof(DungeonRoomRoot));
        this.itemBreakIngredientSerializer = new XmlSerializer(typeof(ItemBreakIngredientRoot));
        this.itemGemstoneUpgradeSerializer = new XmlSerializer(typeof(ItemGemstoneUpgradeRoot));
        this.itemLapenshardUpgradeSerializer = new XmlSerializer(typeof(ItemLapenshardUpgradeRoot));
        this.setItemOptionSerializer = new XmlSerializer(typeof(SetItemOptionRoot));
        this.jobSerializer = new XmlSerializer(typeof(JobRoot));
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
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("colorpalette_achieve.xml"));
        var data = paletteSerializer.Deserialize(reader) as ColorPaletteRoot;
        Debug.Assert(data != null);

        foreach (ColorPalette palette in data.color) {
            yield return (palette.id, palette);
        }
    }

    public IEnumerable<(int JobCode, string Slot, IList<DefaultItems.Item> Items)> ParseDefaultItems() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("defaultitems.xml"));
        var data = defaultItemsSerializer.Deserialize(reader) as DefaultItems;
        Debug.Assert(data != null);

        foreach (DefaultItems.Key key in data.key) {
            foreach (DefaultItems.Slot slot in key.slot) {
                yield return (key.jobCode, slot.name, slot.item);
            }
        }
    }

    public IEnumerable<(int Id, DungeonRoom Item)> ParseDungeonRoom() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/dungeonroom.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = dungeonRoomSerializer.Deserialize(reader) as DungeonRoomRoot;
        Debug.Assert(data != null);

        foreach (DungeonRoom dungeon in data.dungeonRoom) {
            yield return (dungeon.dungeonRoomID, dungeon);
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

    public IEnumerable<(int Id, SetItemOption Option)> ParseSetItemOption() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/setitemoption.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = setItemOptionSerializer.Deserialize(reader) as SetItemOptionRoot;
        Debug.Assert(data != null);

        foreach (SetItemOption option in data.option) {
            yield return (option.id, option);
        }
    }
}
