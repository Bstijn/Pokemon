namespace Classes
{
    public interface ISellBuy
    {
        void BuyItem(Consumable consumable, int amount);
        void SellItem(Consumable consumable, int amount);
    }
}
