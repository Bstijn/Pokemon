
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SQLContexts
{
    public class PokedexContext : IPokedexContext
    {
        public List<object[]> GetSeenPokemon()
        {
            return new List<object[]>();
        }

        public List<object[]> GetOwnedPokemon()
        {
            return new List<object[]>();
        }
    }
}
