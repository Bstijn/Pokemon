
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ILocationContext
    {
        List<object[]> GetCharacters();

        List<object[]> GetPassages();

        List<object[]> GetPokemon();
    }
}
