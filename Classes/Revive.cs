namespace Classes
{
    public class Revive : Consumable
    {
        public int Percentage { get; private set; }

        public Revive(int id, string name, int cost, string description, int percentage) : base(id, name, cost, description)
        {
            Percentage = percentage;
        }

        public override void Use(Pokemon pokemon)
        {
            if (pokemon.Fainted)
            {
                pokemon.Revive();
            }
        }
    }
}
