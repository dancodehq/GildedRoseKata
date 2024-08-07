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

    }
}
