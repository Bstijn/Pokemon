using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface IPokedexContext
    {
        List<object[]> GetSeenPokemon();

        List<object[]> GetOwnedPokemon();
    }
}
