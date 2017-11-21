using System.Collections.Generic;

namespace Classes
{
    public abstract class Area : Location
    {

        public int MinLevel { get; private set; }
        public int MaxLevel { get; private set; }
        public decimal EncounterChance { get; private set; }
        public List<PokedexPokemon> AvailablePokemons { get; private set; }
        public Area(int id, int sizeX, int sizeY, string name, List<Passage> passages, int minLevel, int maxLevel, decimal encounterChance, List<PokedexPokemon> availablePokemons) : base(id, sizeX, sizeY, name, passages)
        {
            MinLevel = minLevel;
            MaxLevel = maxLevel;
            EncounterChance = encounterChance;
            AvailablePokemons = availablePokemons;
        }

    }
}
