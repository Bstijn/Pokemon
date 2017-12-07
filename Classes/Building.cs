using System.Collections.Generic;

namespace Classes
{
    public abstract class Building : Location
    {
        public Building(int id, string name, List<Passage> passages) : base(id, name, passages)
        {
        }
    }
}
