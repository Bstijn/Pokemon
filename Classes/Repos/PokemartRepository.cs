using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Repos
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
