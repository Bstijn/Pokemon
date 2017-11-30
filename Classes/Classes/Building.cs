using System.Collections.Generic;

namespace Classes.Classes
{
    public abstract class Building : Location
    {
        public Building(int id, int sizeX, int sizeY, string name, List<Passage> passages) : base(id, sizeX, sizeY, name, passages)
        {
        }
    }
}
