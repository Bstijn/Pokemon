using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Repositories
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
