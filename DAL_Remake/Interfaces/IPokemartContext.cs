using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface IPokemartContext
    {
        List<object[]> GetConsumables();
    }
}
