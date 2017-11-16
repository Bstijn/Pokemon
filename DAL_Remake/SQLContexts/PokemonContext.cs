using DAL_Remake.Interfaces;
using System.Collections.Generic;

namespace DAL_Remake.SQLContexts
{
    public class PokemonContext :IPokemonContext
    {
        public List<object[]> GetMoves()
        {
            return new List<object[]>();
        }

        public object[] GetPokemonType()
        {
            return null;
        }
    }
}
