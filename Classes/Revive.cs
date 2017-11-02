namespace Classes
{
    public class Revive : Consumable
    {
        public int Percentage { get; private set; }

        public override void Use(Pokemon pokemon)
        {
            if (pokemon.Fainted)
            {
                pokemon.Revive();
            }
        }
    }
}
