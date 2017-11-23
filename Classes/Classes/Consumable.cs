namespace Classes.Classes
{
    public abstract class Consumable : Item
    {
        public Consumable(int id, string name, int cost, string description) : base(id, name, cost, description)
        {

        }

        public abstract void Use(Pokemon targetPokemon);
    }
}
