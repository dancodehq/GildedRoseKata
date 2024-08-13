using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData("Sword", 5, 4)]
        [InlineData("Aged Brie", 5, 4)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 4)]
        [InlineData("Conjured Moon Cake", 5, 4)]
        public void Sell_in_is_updated_each_day(string itemName, int sellIn, int expectedSellIn)
        {
            List<Item> items = [new Item { Name = itemName, Quality = 10, SellIn = sellIn }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(expectedSellIn, items[0].SellIn);
        }

        [Theory]
        [InlineData(5, 10, 9)]
        [InlineData(0, 10, 8)]
        [InlineData(0, 1, 0)]
        public void Normal_item_quality_is_updated_each_day(int sellIn, int quality, int expectedQuality)
        {
            List<Item> items = [new Item { Name = "Sword", Quality = quality, SellIn = sellIn }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Theory]
        [InlineData(5, 10, 8)]
        [InlineData(0, 10, 6)]
        [InlineData(0, 3, 0)]
        public void Conjured_item_quality_is_updated_each_day(int sellIn, int quality, int expectedQuality)
        {
            List<Item> items = [new Item { Name = "Conjured Moon Cake", Quality = quality, SellIn = sellIn }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Theory]
        [InlineData(5, 10, 11)]
        [InlineData(0, 10, 12)]
        [InlineData(0, 49, 50)]
        public void Aged_brie_item_quality_is_updated_each_day(int sellIn, int quality, int expectedQuality)
        {
            List<Item> items = [new Item { Name = "Aged Brie", Quality = quality, SellIn = sellIn }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Theory]
        [InlineData(15, 10, 11)]
        [InlineData(10, 10, 12)]
        [InlineData(5, 10, 13)]
        [InlineData(0, 10, 0)]
        public void Backstage_pass_quality_is_updated_each_day(int sellIn, int quality, int expectedQuality)
        {
            List<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = quality, SellIn = sellIn }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void Sulfuras_quality_does_not_change()
        {
            List<Item> items = [new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 0 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void Sulfuras_sell_in_does_not_change()
        {
            List<Item> items = [new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 10 }];
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(10, items[0].SellIn);
        }
    }
}
