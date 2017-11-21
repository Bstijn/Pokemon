using System.Collections.Generic;

namespace Classes
{
    public class EnemyHQ : Building
    {
        public EnemyHQ(int id, int sizeX, int sizeY, string name, List<Passage> passages) : base(id, sizeX, sizeY, name, passages)
        {
        }
    }
}
