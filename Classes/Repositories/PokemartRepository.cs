using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Repositories
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
