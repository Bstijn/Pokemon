namespace Classes
{
    public class KeyItem : NonConsumable
    {
        public KeyItem(int id, string name, int cost, string description,bool isUsable) : base(id, name, cost, description)
        {
            this.IsUsable = isUsable;
        }

        public bool IsUsable { get; private set; }
    }
}
