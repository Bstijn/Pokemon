using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface ILocationContext
    {
        object[] GetGymleader(int locationID);

        object[] GetNurse(int locationID);

        object[] GetShopkeeper(int locationID);

        List<object[]> GetOpponents(int locationID);

        List<object[]> GetBystanders(int locationID);

        List<object[]> GetPassages(int locationID);

        List<object[]> GetEncounterablePokemon(int locationID);

        List<object[]> GetPokemonMoves(int pokemonID);

        object[] GetPokemonType(int pokemonID);
        object[] GetMoveType(int moveID);

        List<object[]> GetRevives(int characterID);

        List<object[]> GetPotions(int characterID);

        List<object[]> GetPokeballs(int characterID);

        List<object[]> GetInventory(int characterID);

        object[] GetCurrentLocation(int locationID);

        object[] GetEncounterChance(int locationID);

        List<object[]> GetPokemonFromOpponent(int characterID);
    }
}
