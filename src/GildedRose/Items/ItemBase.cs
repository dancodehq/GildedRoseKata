using System;

namespace GildedRoseKata.Items;

abstract class ItemBase
{
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
        Item.Quality = Clamp(Item.Quality - step);
    }

    protected void IncreaseQuality()
    {
        Item.Quality = Clamp(Item.Quality + 1);
    }

    protected void ResetQualityToZero()
    {
        Item.Quality = Item.Quality - Item.Quality;
    }

    private int Clamp(int newItemQuality)
    {
        const int MinQuality = 0;
        const int MaxQuality = 50;
        
        return Math.Clamp(newItemQuality, MinQuality, MaxQuality);
    }
}