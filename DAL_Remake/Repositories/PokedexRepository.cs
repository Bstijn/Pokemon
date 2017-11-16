using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
