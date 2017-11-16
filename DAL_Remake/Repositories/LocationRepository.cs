using System.Collections.Generic;
using DAL_Remake.Interfaces;

namespace DAL_Remake.Repositories
{
    public class LocationRepository
    {
        private ILocationContext context;

        public List<object[]> GetCharacters()
        {
            return context.GetCharacters();
        }

        public List<object[]> GetPassages()
        {
            return context.GetPassages();
        }

        public List<object[]> GetPokemon()
        {
            return context.GetPokemon();
        }
    }
}
