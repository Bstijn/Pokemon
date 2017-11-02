namespace Classes
{
    public class Potion : Consumable
    {
        public int HealAmount { get; private set; }

        public override void Use(Pokemon pokemon)
        {
            pokemon.HealByPotion(this);
        }
    }
}
