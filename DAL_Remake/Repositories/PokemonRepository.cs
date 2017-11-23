using System.Collections.Generic;
using DAL_Remake.Interfaces;

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
