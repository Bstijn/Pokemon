using System;

namespace Classes
{
    public class Pokemon
    {
        public int Id { get; private set; }
        public bool InParty { get; private set; }
        public int Level { get; private set; }
        public int CurrentHp { get; private set; }
        public int MaxHp { get; private set; }
        public int Xp { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public PokedexPokemon MastePokemon { get; private set; }
        public Move[] Moves { get; private set; } = new Move[4];
        

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }
        public void DealDamage(Move move)
        {
            throw new NotImplementedException();
        }

        public void LevelUp()
        {
            throw new NotImplementedException();
        }

        public void Evolve()
        {
            throw new NotImplementedException();
        }
    }
}
