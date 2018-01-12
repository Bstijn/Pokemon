using Classes.Repos;
using DAL_Remake.SQLContexts;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    public abstract class Location
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private List<Passage> passages;
        private int sizeX;
        private int sizeY;

        protected LocationRepository repo;

        public Location(int id, string name, List<Passage> passages)
        {
            Id = id;
            Name = name;
            this.passages = passages;
            repo = new LocationRepository();
        }

        public Location(int id, string name)
        {
            Id = id;
            Name = name;
            repo = new LocationRepository();
            passages = repo.GetPassages(id);
        }

        public void SetPassages(List<Passage> passages)
        {
            this.passages = passages;
        }

        public List<Passage> GetPassages()
        {
            return passages;
        }
        public Passage GetPassageByCoords(int x, int y)
        {
            return passages.FirstOrDefault(passage => passage.FromX == x && passage.FromY == y);
        }
    }
}
