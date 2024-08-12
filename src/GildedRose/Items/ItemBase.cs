using System;

namespace GildedRoseKata.Items;

abstract class ItemBase
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