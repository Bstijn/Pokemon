using DAL_Remake.Interfaces;
using System.Collections.Generic;

namespace DAL_Remake.SQLContexts
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
