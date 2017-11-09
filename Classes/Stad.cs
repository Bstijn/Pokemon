using System.Collections.Generic;

namespace Classes
{
    public class Stad : Area
    {
        public bool Visited { get; private set; }

        public Stad(int id, int sizeX, int sizeY, string name, List<Passage> passages, int minLevel, int maxLevel, decimal encounterChance, List<Pokemon> availablePokemons, bool visited) : base(id, sizeX, sizeY, name, passages, minLevel, maxLevel, encounterChance, availablePokemons)
        {
            Visited = visited;
        }
    }
}
