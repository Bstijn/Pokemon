using System;
using System.Collections.Generic;
using Classes;

namespace DAL_Remake.Interfaces
{
    public interface IPokemonContext
    {
        List<object[]> GetMoves(int pokemonID);

        object[] GetPokemonType(int pokedexPokemonID);

        object[] GetMoveType(int moveID);

        object GetEffectiveness(int attackTypeID, int defenseTypeID);
        object[] GetNextLevelUpXp(int level);

    }
}
