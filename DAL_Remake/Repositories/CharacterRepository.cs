using DAL_Remake.SQLContexts;
using DAL_Remake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Remake.Repositories
{
    public class CharacterRepository
    {
        private ICharacterContext context;

        public CharacterRepository(ICharacterContext context)
        {
            context = new CharacterContext();
        }

        public List<object[]> GetItems(int characterID)
        {
            return context.GetItems(characterID);
        }

        public List<object[]> GetPokemon(int characterID)
        {
            return context.GetPokemon(characterID);
        }

        public List<object[]> GetDialogues(int characterID)
        {
            return context.GetDialogues(characterID);
        }
    }
}
