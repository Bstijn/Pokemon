using System.Collections.Generic;

namespace Classes.Classes
{
    public class Gym : Building
    {
        public Gym(int id, int sizeX, int sizeY, string name, List<Passage> passages) : base(id, sizeX, sizeY, name, passages)
        {
        }
    }
}
