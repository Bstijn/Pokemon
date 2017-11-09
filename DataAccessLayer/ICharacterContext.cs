using Classes.Classes;
using System.Collections.Generic;

namespace DataAccessLayer
{
    interface ICharacterContext
    {
        List<Character> GetCharactersFromLocation(Location location);
    }
}
