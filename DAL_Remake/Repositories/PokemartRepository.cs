using DAL_Remake.SQLContexts;
using DAL_Remake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Remake.Repositories
{
    public class PokemartRepository
    {
        private IPokemartContext context;

        public PokemartRepository(IPokemartContext context)
        {
            context = new PokemartContext();
        }

        public List<object[]> GetConsumables(string pokemartName)
        {
            return context.GetConsumables(pokemartName);
        }
    }
}
