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
            return item.Name switch
            {
                "Aged Brie" => new AgedBrie(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePass(item),
                "Sulfuras, Hand of Ragnaros" => new Sulfuras(item),
                { } x when x.StartsWith("Conjured") => new ConjuredItem(item),
                _ => new NormalItem(item)
            };
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
                    _item.Quality = _item.Quality - 2;
                }

                _item.SellIn = _item.SellIn - 1;

                if (_item.SellIn < 0)
                {
                    if (_item.Quality > 0)
                    {
                        _item.Quality = _item.Quality - 2;
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
