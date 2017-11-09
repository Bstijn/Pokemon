using Classes;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class CharacterContext : ICharacterContext
    {
        public List<Character> GetCharactersFromLocation(Location location)
        {
            List<Character> characters = new List<Character>();

            DbConnection.Read("SELECT * FROM Character c, CharacterLocation cl, Location l WHERE c.ID = cl.CharacterID AND cl.LocationID = " + location.Id);



            return characters;
        }
    }
}
