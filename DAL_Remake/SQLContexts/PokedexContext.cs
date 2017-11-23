using DAL_Remake.Interfaces;
using System.Collections.Generic;

namespace DAL_Remake.SQLContexts
{
    public class PokedexContext : IPokedexContext
    {
        public List<object[]> GetSeenPokemon()
        {
            return new List<object[]>();
        }

        public List<object[]> GetOwnedPokemon()
        {
            return new List<object[]>();
        }
    }
}
