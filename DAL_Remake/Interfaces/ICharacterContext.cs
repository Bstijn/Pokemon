using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface ICharacterContext
    {
        List<object[]> GetItems(int characterID);

        List<object[]> GetPokemon(int characterID);

        List<object[]> GetDialogues(int characterID);
    }
}
