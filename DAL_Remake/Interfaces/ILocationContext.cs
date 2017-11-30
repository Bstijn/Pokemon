using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface ILocationContext
    {
        object[] GetGymleader(int locationID);

        object[] GetNurse(int locationID);

        object[] GetShopkeeper(int locationID);

        List<object[]> GetOpponents(int locationID);

        List<object[]> GetBystanders(int locationID);

        List<object[]> GetPassages(int locationID);

        List<object[]> GetPokemon(int locationID);
    }
}
