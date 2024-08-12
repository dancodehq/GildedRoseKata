namespace GildedRoseKata.Items;

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