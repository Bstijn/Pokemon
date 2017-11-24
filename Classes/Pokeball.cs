namespace Classes
{
    public class Pokeball : Consumable
    {
        public Pokeball(int id, string name, int cost, string description, decimal catchrate) : base(id, name, cost, description)
        {
            this.CatchRate = catchrate;
        }

        public decimal CatchRate { get; private set; }
    }

    public override void Use(Pokemon targetPokemon)
    {

    }
}
