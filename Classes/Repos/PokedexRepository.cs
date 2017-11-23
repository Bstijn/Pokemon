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

        public List<Pokemon> GetSeenPokemon()
        {
            List<object[]> data = context.GetSeenPokemon();
            List<Pokemon> pokemon = new List<Pokemon>();


            //TODO: Fixen dat er een hele pokemon word opgehaald
            return pokemon;
        }

        public List<Pokemon> GetOwnedPokemon()
        {
            List<object[]> data = context.GetSeenPokemon();
            List<Pokemon> pokemon = new List<Pokemon>();

            //TODO: Fixen dat er een hele pokemon word opgehaald
            return pokemon;
        }
    }
}
