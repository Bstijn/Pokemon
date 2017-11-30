using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class PokemonMoves
    {
        public int Id { get; private set; }
        public int MinLevel { get; private set; }
        public PokedexMove MasterMove { get; private set; }
    }
}
