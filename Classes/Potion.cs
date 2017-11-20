namespace Classes
{
    public class Potion : Consumable
    {
        public Potion(int id, string name, int cost, string description, int healAmount) : base(id, name, cost, description)
        {
            this.HealAmount = healAmount;
        }

        public int HealAmount { get; private set; }
    }
}
