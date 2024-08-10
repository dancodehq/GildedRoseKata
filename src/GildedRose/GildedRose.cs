using System;
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

        class Sulfuras : ItemBase
        {
            private readonly Item _item;

            public Sulfuras(Item item)
            {
                _item = item;
            }

            public override void Update()
            {
                
            }
        }

        abstract class ItemBase
        {
            public abstract void Update();
        }

        class NormalItem : ItemBase
        {
            private readonly Item _item;

            public NormalItem(Item item)
            {
                _item = item;
            }

            public override void Update()
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

        class ConjuredItem : ItemBase
        {
            private readonly Item _item;

            public ConjuredItem(Item item)
            {
                _item = item;
            }

            public override void Update()
            {
                if (_item.Quality > 0)
                {
                    _item.Quality = Math.Clamp(_item.Quality - 2, 0, 50);
                }

                _item.SellIn = _item.SellIn - 1;

                if (_item.SellIn < 0)
                {
                    if (_item.Quality > 0)
                    {
                        _item.Quality = Math.Clamp(_item.Quality - 2, 0, 50);
                    }
                }
            }
        }

        class BackstagePass : ItemBase
        {
            private readonly Item _item;

            public BackstagePass(Item item)
            {
                _item = item;
            }

            public override void Update()
            {
                if (_item.Quality < 50)
                {
                    _item.Quality = _item.Quality + 1;

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

                _item.SellIn = _item.SellIn - 1;

                if (_item.SellIn < 0)
                {
                    _item.Quality = _item.Quality - _item.Quality;
                }
            }
        }

        class AgedBrie : ItemBase
        {
            private readonly Item _item;

            public AgedBrie(Item item)
            {
                _item = item;
            }

            public override void Update()
            {
                if (_item.Quality < 50)
                {
                    _item.Quality = _item.Quality + 1;
                }

                _item.SellIn = _item.SellIn - 1;

                if (_item.SellIn < 0)
                {
                    if (_item.Quality < 50)
                    {
                        _item.Quality = _item.Quality + 1;
                    }
                }
            }
        }
    }
}
