using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface IPokemartContext
    {
        List<object[]> GetRevives(int pokemartID);

        List<object[]> GetPotions(int pokemartID);

        List<object[]> GetPokeballs(int pokemartID);
    }
}
