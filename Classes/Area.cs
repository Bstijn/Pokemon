using System.Collections.Generic;

namespace Classes
{
    public abstract class Area : Location
    {
        public int MinLevel { get; private set; }
        public int MaxLevel { get; private set; }
        public decimal EncounterChance { get; private set; }
        public List<PokedexPokemon> AvailablePokemons { get; private set; }
    }
}
