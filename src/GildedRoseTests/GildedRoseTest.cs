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

        [Fact]
        public void Aged_brie_sell_by_decreases_by_one_each_day()
        {
            List<Item> items = [new Item { Name = "Aged Brie", Quality = 10, SellIn = 5 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(4, items[0].SellIn);
        }

        [Theory, InlineData(0), InlineData(1)]
        public void Sulfuras_quality_never_degrades(int sellIn)
        {
            List<Item> items = [new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 50, SellIn = sellIn }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void Sulfuras_sell_by_never_decreases()
        {
            List<Item> items = [new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 50, SellIn = 10 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(10, items[0].SellIn);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Backstage_pass_quality_improves_by_two_when_ten_days_or_less_remaining(int sellIn)
        {
            List<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 30, SellIn = sellIn }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(32, items[0].Quality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Backstage_pass_quality_improves_by_three_when_five_days_or_less_remaining(int sellIn)
        {
            List<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 30, SellIn = sellIn }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(33, items[0].Quality);
        }

        [Fact]
        public void Backstage_pass_quality_drops_to_zero_after_concert()
        {
            List<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 30, SellIn = 0 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }

    }
}
