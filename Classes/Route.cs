using System.Collections.Generic;

namespace Classes
{
    public class Route : Area
    {
        public Route(int id, string name, List<Passage> passages, int minLevel, int maxLevel, decimal encounterChance, List<Pokemon> availablePokemons) : base(id, name, passages, minLevel, maxLevel, encounterChance, availablePokemons)
        {
        }
    }
}
