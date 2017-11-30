
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SQLContexts
{
    public class LocationContext : ILocationContext
    {
        public List<object[]> GetCharacters()
        {
            return new List<object[]>();
        }

        public List<object[]> GetPassages()
        {
            return new List<object[]>();
        }

        public List<object[]> GetPokemon()
        {
            return new List<object[]>();
        }
    }
}
