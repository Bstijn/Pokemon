using System.Collections.Generic;
using Classes;

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
        object[] Load();
        object[] GetCurrentLocation(int characterID);

        string GetLocationType(int locationID);

        void InsertIntro(int pokemonID, string CharacterName, string Gender);
        int GetCharacterIDForPlayer();
        object[] GetCharacter(int characterID);
        void InsertPokemon(int lvl, int pokedexPokemonID, int? inparty);
        void UpdatePokemon(Pokemon pokemon);
        void UpdateMove(Move move, Pokemon pokemon);
    }
}
