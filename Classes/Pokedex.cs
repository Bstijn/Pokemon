using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Pokedex
    {
        public List<Pokemon> SeenPokemon = new List<Pokemon>();
        public List<Pokemon> OwnedPokemon = new List<Pokemon>();
        public Pokedex(List<Pokemon> seenPokemon, List<Pokemon> ownedPokemon)
        {
            this.SeenPokemon = seenPokemon;
            this.OwnedPokemon = ownedPokemon;
        }
        public void AddToOwnedPokemon(Pokemon pokemon)
        {
            if (!OwnedPokemon.Contains(pokemon))
            {
                OwnedPokemon.Add(pokemon);
            }
            
        }
        public void AddToSeenPokemon(Pokemon pokemon)
        {
            if (!SeenPokemon.Contains(pokemon))
            {
                SeenPokemon.Add(pokemon);
            }
        }
    }
}
