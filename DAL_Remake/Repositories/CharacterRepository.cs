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

        public List<object[]> GetItems()
        {
            return context.GetItems();
        }

        public List<object[]> GetPokemon()
        {
            return context.GetPokemon();
        }

        public List<object[]> GetDialogues()
        {
            return context.GetDialogues();
        }
    }
}
