namespace Classes
{
    public class Possesion
    {
        public int Quantity { get; private set; }
        public Item Item { get; private set; }

        public Possesion(int quantity, Item item)
        {
            Quantity = quantity;
            Item = item;
        }

        public void ItemUsed()
        {
            Quantity--;
        }
    }
}
