using DAL_Remake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
