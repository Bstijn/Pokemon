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

        List<object[]> GetPokemon(int characterID);

        List<object[]> GetDialogues(int characterID);
    }
}
