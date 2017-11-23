

using DataAccessLayer;
using System.Collections.Generic;

namespace Classes.Repositories
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
