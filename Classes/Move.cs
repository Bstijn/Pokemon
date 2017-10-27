using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Move
    {
        public int Id { get; private set; }
        public int CurrentPP { get; private set; }
        public PokemonMoves PokemonMoves { get; private set; }
    }
}
