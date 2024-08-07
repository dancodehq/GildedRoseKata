using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void Normal_item_quality_degrades_by_one_each_day_when_sell_by_is_in_the_future()
        {
            List<Item> items = [new Item { Name = "Sword", Quality = 10, SellIn = 5 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(9, items[0].Quality);
        }
        
        [Fact]
        public void Normal_item_quality_degrades_by_two_each_day_when_sell_by_is_exceeded()
        {
            List<Item> items = [new Item { Name = "Sword", Quality = 10, SellIn = 0 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void Normal_item_sell_by_decreases_by_one_each_day()
        {
            List<Item> items = [new Item { Name = "Sword", Quality = 10, SellIn = 5 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(4, items[0].SellIn);
        }

        [Fact]
        public void Normal_item_quality_does_not_degrade_past_zero()
        {
            List<Item> items = [new Item { Name = "Sword", Quality = 0, SellIn = 0 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void Aged_brie_quality_improves_by_one_each_day_when_sell_by_is_in_the_future()
        {
            List<Item> items = [new Item { Name = "Aged Brie", Quality = 30, SellIn = 5 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(31, items[0].Quality);
        }
        
        [Fact]
        public void Aged_brie_quality_improves_by_two_each_day_when_sell_by_is_exceeded()
        {
            List<Item> items = [new Item { Name = "Aged Brie", Quality = 30, SellIn = 0 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(32, items[0].Quality);
        }

        [Fact]
        public void Aged_brie_quality_never_improves_past_fifty()
        {
            List<Item> items = [new Item { Name = "Aged Brie", Quality = 50, SellIn = 0 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
        }

    }
}
