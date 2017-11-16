using System.Collections.Generic;
using DAL_Remake.Interfaces;

namespace DAL_Remake.Repositories
{
    public class PokedexRepository
    {
        private IPokedexContext context;

        public List<object[]> GetSeenPokemon()
        {
            return context.GetSeenPokemon();
        }

        public List<object[]> GetOwnedPokemon()
        {
            return context.GetOwnedPokemon();
        }

    }
}
