using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Remake.Interfaces
{
    public interface ICharacterContext
    {
        List<object[]> GetItems(int characterID);

        List<object[]> GetPokemon(int characterID);

        List<object[]> GetDialogues(int characterID);
    }
}
