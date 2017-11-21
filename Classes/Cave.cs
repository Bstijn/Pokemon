using System.Collections.Generic;

namespace Classes
{
    public class Cave : Area
    {
        public Cave(int id, int sizeX, int sizeY, string name, List<Passage> passages, int minLevel, int maxLevel, decimal encounterChance, List<PokedexPokemon> availablePokemons) : base(id, sizeX, sizeY, name, passages, minLevel, maxLevel, encounterChance, availablePokemons)
        {
        }
    }
}
