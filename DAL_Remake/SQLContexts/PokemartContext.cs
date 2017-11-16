using DAL_Remake.Interfaces;
using System.Collections.Generic;

namespace DAL_Remake.SQLContexts
{
    public class PokemartContext : IPokemartContext
    {
        public List<object[]> GetConsumables()
        {
            return new List<object[]>();
        }
    }
}
