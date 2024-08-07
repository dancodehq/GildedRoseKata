using System.Collections.Generic;

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
                var isAgedBrie = item.Name == "Aged Brie";
                if (isAgedBrie)
                {
                    UpdateAgedBrie(item);
                }
                else
                {
                    var isBackstagePass = item.Name == "Backstage passes to a TAFKAL80ETC concert";
                    if (isBackstagePass)
                    {
                        UpdateBackstagePass(item);
                    }
                    else
                    {
                        var isSulfuras = item.Name == "Sulfuras, Hand of Ragnaros";
                        if (isSulfuras)
                        {
                            UpdateSulfuras(item);
                        }
                        else
                        {
                            UpdateNormal(item);
                        }
                    }
                }
            }
        }

        private void UpdateNormal(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }

        private void UpdateSulfuras(Item item)
        {
            if (item.Quality > 0)
            {
            }

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                }
            }
        }

        private void UpdateBackstagePass(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }

        private void UpdateAgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }
}
