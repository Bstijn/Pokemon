using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Remake.Interfaces
{
    public interface IPokemartContext
    {
        List<object[]> GetConsumables(string pokemartName);
    }
}
