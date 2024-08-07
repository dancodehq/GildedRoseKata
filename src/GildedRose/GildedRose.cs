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
                else
                {
                    var isBackstagePass = item.Name == "Backstage passes to a TAFKAL80ETC concert";
                    if (isBackstagePass)
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
                    else
                    {
                        var notSulfuras = item.Name != "Sulfuras, Hand of Ragnaros";
                        if (item.Quality > 0)
                        {
                            if (notSulfuras)
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }

                        if (notSulfuras)
                        {
                            item.SellIn = item.SellIn - 1;
                        }

                        if (item.SellIn < 0)
                        {
                            if (item.Quality > 0)
                            {
                                if (notSulfuras)
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
