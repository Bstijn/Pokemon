using System.Collections.Generic;

namespace Classes
{
    public class Cave : Area
    {
        public Cave(int id, string name, List<Passage> passages, int minLevel, int maxLevel, decimal encounterChance, List<Pokemon> availablePokemons) : base(id, name, passages, minLevel, maxLevel, encounterChance, availablePokemons)
        {
        }
    }
}
