using System.Collections.Generic;

namespace DAL_Remake.Interfaces
{
    public interface IPokemonContext
    {
        List<object[]> GetMoves();

        object[] GetPokemonType();
    }
}
