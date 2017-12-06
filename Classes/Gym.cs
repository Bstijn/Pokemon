using System.Collections.Generic;

namespace Classes
{
    public class Gym : Building
    {
        public Gym(int id, string name, List<Passage> passages) : base(id, name, passages)
        {
        }
    }
}
