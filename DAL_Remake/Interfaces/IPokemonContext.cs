﻿using System.Collections.Generic;
using Classes;

namespace DAL_Remake.Interfaces
{
    public interface IPokemonContext
    {
        List<object[]> GetMoves(int pokemonID);

        object[] GetPokemonType(int pokedexPokemonID);

        LevelUpXP GetNextLevelUpXp(int level);

    }
}
