namespace Classes
{
    public class Potion : Consumable
    {
        public int HealAmount { get; private set; }

        public Potion(int id, string name, int cost, string description, int healAmount) : base(id, name, cost, description)
        {
            HealAmount = healAmount;
        }

        public override void Use(Pokemon pokemon)
        {
            pokemon.HealByPotion(this);
        }
    }
}
