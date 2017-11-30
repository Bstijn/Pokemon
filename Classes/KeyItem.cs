namespace Classes
{
    public class KeyItem : NonConsumable
    {
        public KeyItem(int id, string name, string description,bool isUsable) : base(id, name, description)
        {
            this.IsUsable = isUsable;
        }

        public bool IsUsable { get; private set; }
    }
}
