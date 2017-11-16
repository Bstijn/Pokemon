using DAL_Remake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
