using System;

namespace Classes
{
    public class Pokeball : Consumable
    {
        public decimal CatchRate { get; private set; }
        public int BallValue { get; }

        public Pokeball(int id, string name, int cost, string description, decimal catchRate, int ballValue) : base(id, name, cost, description)
        {
            CatchRate = catchRate;
            BallValue = ballValue;
        }

        public override void Use(Pokemon targetPokemon)
        {
            if (CalculateCatch(Name, BallValue, targetPokemon.MaxHp, targetPokemon.CurrentHp, targetPokemon.CaptureRate))
            {
                // catch pokemon
            }
        }

        public bool CalculateCatch(string ballName, int ballValue, int maxHP, int currentHP, int pokemonCaptureRate)
        {
            if (ballName == "Master Ball")
            {
                return true;
            }

            Random catchrate = new Random();
            int c = catchrate.Next(0, ballValue);

            if (c > pokemonCaptureRate)
            {
                return false;
            }
            Random random = new Random();
            int m = random.Next(0, 255);
            int ball = GetBallRate(ballName);

            int f = (maxHP * 255 * 4) / (currentHP * ball);
            if (f < m)
            {
                return false;
            }
            return true;
        }

        private int GetBallRate(string ballName)
        {
            if (ballName == "Great Ball")
            {
                return 8;
            }
            return 12;
        }
    }
}
