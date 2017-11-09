using Classes.Classes;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class CharacterContext : ICharacterContext
    {
        public List<Character> GetCharactersFromLocation(Location location)
        {
            List<Character> characters = new List<Character>();

            //List<object[]> data = DbConnection.Read("SELECT * FROM Character c, CharacterLocation cl, Location l WHERE c.ID = cl.CharacterID AND cl.LocationID = " + location.Id);

            //foreach (object[] row in data)
            //{
            //    characters.Add(new Character());
            //}

            return characters;
        }

        public List<object[]> GetType(string name)
        {
            return DbConnection.Read("SELECT * FROM Type WHERE Name = " + name);
        }
    }
}
