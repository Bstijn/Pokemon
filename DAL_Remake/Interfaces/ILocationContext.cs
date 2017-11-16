using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface ILocationContext
    {
        List<object[]> GetCharacters();

        List<object[]> GetPassages();

        List<object[]> GetPokemon();
    }
}
