using System.Collections.Generic;

namespace Classes
{
    public class City : Area
    {
        public City(int id, int sizeX, int sizeY, string name, List<Passage> passages, int minLevel, int maxLevel, decimal encounterChance, List<Pokemon> availablePokemons, bool visited) : base(id, sizeX, sizeY, name, passages, minLevel, maxLevel, encounterChance, availablePokemons)
        {
            this.Visited = visited;
        }

        public bool Visited { get; private set;}
    }
}
