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
                var itemStrategy = CreateItemStrategy(item);
                itemStrategy.Update();
            }
        }

        private static ItemStrategyBase CreateItemStrategy(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => new AgedBrieStrategy(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassStrategy(item),
                "Sulfuras, Hand of Ragnaros" => new SulfurasStrategy(item),
                _ => new NormalItemStrategy(item)
            };
        }

        class SulfurasStrategy : ItemStrategyBase
        {
            private readonly Item _item;

            public SulfurasStrategy(Item item)
            {
                _item = item;
            }

            public override void Update()
            {
                
            }
        }

        abstract class ItemStrategyBase
        {
            public abstract void Update();
        }

        class NormalItemStrategy : ItemStrategyBase
        {
            private readonly Item _item;

            public NormalItemStrategy(Item item)
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

        class BackstagePassStrategy : ItemStrategyBase
        {
            private readonly Item _item;

            public BackstagePassStrategy(Item item)
            {
                _item = item;
            }

            public override void Update()
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

        class AgedBrieStrategy : ItemStrategyBase
        {
            private readonly Item _item;

            public AgedBrieStrategy(Item item)
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
