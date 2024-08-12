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

            public Sulfuras(Item item) : base(item)
            {
                _item = item;
            }

            public override void Update()
            {
                
            }
        }

        public abstract class ItemBase
        {
            const int MinQuality = 0;
            const int MaxQuality = 50;
            
            protected Item Item { get; }
            
            protected ItemBase(Item item)
            {
                Item = item;
            }

            public abstract void Update();

            protected bool IsExpired()
            {
                return Item.SellIn < 0;
            }

            protected void DecreaseExpiry()
            {
                Item.SellIn = Item.SellIn - 1;
            }

            protected void DecreaseQuality(int step)
            {
                Item.Quality = Math.Clamp(Item.Quality - step, MinQuality, MaxQuality);
            }

            protected void IncreaseQuality()
            {
                Item.Quality = Math.Clamp(Item.Quality + 1, MinQuality, MaxQuality);
            }

            protected void ResetQualityToZero()
            {
                Item.Quality = Item.Quality - Item.Quality;
            }
        }

        class NormalItem : ItemBase
        {
            public NormalItem(Item item) : base(item)
            {
            }

            public override void Update()
            {
                DecreaseQuality(step: 1);

                DecreaseExpiry();

                if (IsExpired())
                {
                    DecreaseQuality(step: 1);
                }
            }
        }

        class ConjuredItem : ItemBase
        {
            public ConjuredItem(Item item) : base(item)
            {
            }

            public override void Update()
            {
                DecreaseQuality(step: 2);

                DecreaseExpiry();

                if (IsExpired())
                {
                    DecreaseQuality(step: 2);
                }
            }
        }

        class BackstagePass : ItemBase
        {
            public BackstagePass(Item item) : base(item)
            {
            }

            public override void Update()
            {
                IncreaseQuality();

                if (Item.SellIn < 11)
                {
                    IncreaseQuality();
                }

                if (Item.SellIn < 6)
                {
                    IncreaseQuality();
                }

                DecreaseExpiry();

                if (IsExpired())
                {
                    ResetQualityToZero();
                }
            }
        }

        class AgedBrie : ItemBase
        {
            public AgedBrie(Item item) : base(item)
            {
            }

            public override void Update()
            {
                IncreaseQuality();

                DecreaseExpiry();

                if (IsExpired())
                {
                    IncreaseQuality();
                }
            }
        }
    }
}
