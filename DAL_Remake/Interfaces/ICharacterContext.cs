using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface ICharacterContext
    {
        List<object[]> GetItems();

        List<object[]> GetPokemon();

        List<object[]> GetDialogues();
    }
}
