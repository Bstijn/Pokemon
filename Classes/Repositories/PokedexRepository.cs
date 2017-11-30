using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Repositories
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
