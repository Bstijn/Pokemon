namespace Classes
{
    public class Pokeball : Consumable
    {

        public decimal CatchRate { get; private set; }
        public Pokeball(int id, string name, int cost, string description, decimal catchRate) : base(id, name, cost, description)
        {
            this.CatchRate = catchRate;
        }
    }
}
