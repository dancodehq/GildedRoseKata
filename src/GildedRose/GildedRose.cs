using System.Collections.Generic;
using GildedRoseKata.Items;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var gildedRoseItem = CreateItem(item);
                gildedRoseItem.Update();
            }
        }

        private static ItemBase CreateItem(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrie(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePass(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(item);
                case { } x when x.StartsWith("Conjured"):
                    return new ConjuredItem(item);
                default:
                    return new NormalItem(item);
            }
        }
    }
}
