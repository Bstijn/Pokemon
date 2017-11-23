using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Repos
{
    public class PokedexRepository
    {
        private IPokedexContext context;

        public PokedexRepository(IPokedexContext context)
        {
            context = new PokedexContext();
        }

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
