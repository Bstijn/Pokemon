
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SQLContexts
{
    public class PokemartContext : IPokemartContext
    {
        public List<object[]> GetConsumables()
        {
            return new List<object[]>();
        }
    }
}
