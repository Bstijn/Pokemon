using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface ICharacterContext
    {
        List<object[]> GetRevives(int characterID);

        List<object[]> GetPotions(int characterID);

        List<object[]> GetPokeballs(int characterID);

        List<object[]> GetBadges(int characterID);

        List<object[]> GetKeyItems(int characterID);

        List<object[]> GetPokemonFromParty(int characterID);

        List<object[]> GetPokemonMoves(int pokemonID);

        object[] GetPokemonType(int pokemonID);

        List<object[]> GetDialogues(int characterID);

        object[] GetCurrentLocation(int characterID);

        string GetLocationType(int locationID);

        void InsterIntro(int pokemonID, string CharacterName, string Gender);

    }
}
