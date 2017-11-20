using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface ILocationContext
    {
        List<object[]> GetCharacters(int locationID);

        List<object[]> GetPassages();

        List<object[]> GetPokemon();
    }
}
