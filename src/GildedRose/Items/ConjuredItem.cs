namespace GildedRoseKata.Items;

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