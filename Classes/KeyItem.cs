namespace Classes
{
    public class KeyItem : NonConsumable
    {
        public bool IsUsable { get; private set; }

        public KeyItem(int id, string name, int cost, string description, bool isUsable) : base(id, name, cost, description)
        {
            IsUsable = isUsable;
        }

        public void Use()
        {

        }
    }
}
