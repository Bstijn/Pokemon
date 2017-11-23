
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ICharacterContext
    {
        List<object[]> GetItems();

        List<object[]> GetPokemon();

        List<object[]> GetDialogues();
    }
}
