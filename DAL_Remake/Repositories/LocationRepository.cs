using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Remake.Repositories
{
    public class LocationRepository
    {
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

}
}
