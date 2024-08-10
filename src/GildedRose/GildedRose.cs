﻿using System.Collections.Generic;

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
                switch (item.Name)
                {
                    case "Aged Brie":
                        UpdateAgedBrie(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateBackstagePass(item);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        new SulfurasStrategy(item).Update();
                        break;
                    default:
                        new NormalItemStrategy(item).Update();
                        break;
                }
            }
        }

        class SulfurasStrategy
        {
            private readonly Item _item;

            public SulfurasStrategy(Item item)
            {
                _item = item;
            }

            public void Update()
            {
                
            }
        }

        class NormalItemStrategy
        {
            private readonly Item _item;

            public NormalItemStrategy(Item item)
            {
                _item = item;
            }

            public void Update()
            {
                if (_item.Quality > 0)
                {
                    _item.Quality = _item.Quality - 1;
                }

                _item.SellIn = _item.SellIn - 1;

                if (_item.SellIn < 0)
                {
                    if (_item.Quality > 0)
                    {
                        _item.Quality = _item.Quality - 1;
                    }
                }
            }
        }

        class BackstagePassStrategy
        {
            private readonly Item _item;

            public BackstagePassStrategy(Item item)
            {
                _item = item;
            }

            public void Update()
            {
                if (_item.Quality < 50)
                {
                    _item.Quality = _item.Quality + 1;

                    if (_item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (_item.SellIn < 11)
                        {
                            if (_item.Quality < 50)
                            {
                                _item.Quality = _item.Quality + 1;
                            }
                        }

                        if (_item.SellIn < 6)
                        {
                            if (_item.Quality < 50)
                            {
                                _item.Quality = _item.Quality + 1;
                            }
                        }
                    }
                }

                _item.SellIn = _item.SellIn - 1;

                if (_item.SellIn < 0)
                {
                    _item.Quality = _item.Quality - _item.Quality;
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
