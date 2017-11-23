using System.Collections.Generic;

namespace Classes.Classes
{
    public class Pokecenter : Building
    {
        public Pokecenter(int id, int sizeX, int sizeY, string name, List<Passage> passages) : base(id, sizeX, sizeY, name, passages)
        {
        }
    }
}
