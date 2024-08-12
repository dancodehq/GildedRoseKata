namespace GildedRoseKata.Items;

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