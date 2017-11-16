using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Remake.Repositories
{
    public class PokemonRepository
    {
        private IPokemonContext context;

        public List<object[]> GetMoves()
        {
            return context.GetMoves();
        }

        public object[] GetPokemonType()
        {
            return context.GetPokemonType();
        }

    }
}
