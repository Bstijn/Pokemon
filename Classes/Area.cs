using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Area : Location
    {
        public int MinLevel { get; private set; }
        public int MaxLevel { get; private set; }
        public decimal EncounterChance { get; private set; }
        public List<Pokemon> AvailablePokemons { get; private set; }
    }
}
