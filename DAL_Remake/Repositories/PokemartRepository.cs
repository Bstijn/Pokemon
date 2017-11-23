using System.Collections.Generic;
using DAL_Remake.Interfaces;

namespace DAL_Remake.Repositories
{
    public class PokemartRepository
    {
        private IPokemartContext context;

        public List<object[]> GetConsumables()
        {
            return context.GetConsumables();
        }
    }
}
