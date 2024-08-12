namespace GildedRoseKata.Items;

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