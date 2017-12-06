using System.Collections.Generic;

namespace Classes
{
    public class EnemyHQ : Building
    {
        public EnemyHQ(int id, string name, List<Passage> passages) : base(id, name, passages)
        {
        }
    }
}
