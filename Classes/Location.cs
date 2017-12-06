using System.Collections.Generic;

namespace Classes
{
    public abstract class Location
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private List<Passage> passages;

        public Location(int id, string name, List<Passage> passages)
        {
            Id = id;
            Name = name;
            this.passages = passages;
        }

        public Location(int id, string name)
        {
            Id = id;
            Name = name;
            passages = null;
        }

        public void SetPassages(List<Passage> passages)
        {
            this.passages = passages;
        }

        public List<Passage> GetPassages()
        {
            return passages;
        }
    }
}
