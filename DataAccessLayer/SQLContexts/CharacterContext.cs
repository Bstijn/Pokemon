
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class CharacterContext : ICharacterContext
    {
        public List<object[]> GetItems()
        {
            List<object[]> items = new List<object[]>();
            return items;
        }

        public List<object[]> GetPokemon()
        {
            return new List<object[]>();
        }

        public List<object[]> GetDialogues()
        {
            return new List<object[]>();
        }
    }
}
