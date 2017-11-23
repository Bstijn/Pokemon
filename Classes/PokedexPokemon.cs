using System.Collections.Generic;

namespace Classes
{
    public class PokedexPokemon
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool Seen { get; private set; }
        public bool Owned { get; private set; }
        public int EvolveLvl { get; private set; }
        public List<Area> Locations { get; private set; }
        public List<PokemonMoves> AvailableMoves { get; private set; }
        public Type Type { get; private set; }
    }
}
