using System.Collections.Generic;

namespace Classes
{
    public class Pokecenter : Building
    {
        public Pokecenter(int id, string name, List<Passage> passages) : base(id, name, passages)
        {
        }
    }
}
