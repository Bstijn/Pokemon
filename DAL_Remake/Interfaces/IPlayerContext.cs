using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface IPlayerContext
    {
        void Save();
        object[] Load();
        List<object[]> GetPokemonFromParty(int characterID);
        object[] GetPokemonType(int characterID);
        List<object[]> GetPokemonMoves(int pokemonID);
        List<object[]> GetRevives(int characterID);
        List<object[]> GetPotions(int characterID);
        List<object[]> GetPokeballs(int characterID);
        List<object[]> GetBadges(int characterID);
        List<object[]> GetKeyItems(int characterID);
    }
}
