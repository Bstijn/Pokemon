using System.Collections.Generic;

namespace Classes
{
    public class Route : Area
    {
        public Route(int id, int sizeX, int sizeY, string name, List<Passage> passages, int minLevel, int maxLevel, decimal encounterChance, List<Pokemon> availablePokemons) : base(id, sizeX, sizeY, name, passages, minLevel, maxLevel, encounterChance, availablePokemons)
        {
        }
    }
}
