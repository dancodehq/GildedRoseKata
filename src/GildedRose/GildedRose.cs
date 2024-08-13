using System.Collections.Generic;
using System.Linq;
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
            var mappedItems = Items.Select<Item, ItemBase>(item => item.Name switch
            {
                "Aged Brie" => new AgedBrie(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePass(item),
                "Sulfuras, Hand of Ragnaros" => new Sulfuras(item),
                { } x when x.StartsWith("Conjured") => new ConjuredItem(item),
                _ => new NormalItem(item)
            });
                
            foreach (var item in mappedItems)
            {
                item.Update();
            }
        }
    }
}
