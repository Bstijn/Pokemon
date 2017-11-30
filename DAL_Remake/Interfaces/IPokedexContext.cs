using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface IPokedexContext
    {
        List<object[]> GetSeenPokemon();

        List<object[]> GetOwnedPokemon();

        object[] GetPokemonType(int pokemonID);

        List<object[]> GetPokemonMoves(int pokemonID);
    }
}
