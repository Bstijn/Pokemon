using System.Collections.Generic;

namespace Classes
{
    public abstract class Location
    {
        public int Id { get; private set; }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public string Name { get; private set; }
        public List<Passage> Passages { get; private set; }

        public Location(int id, int sizeX, int sizeY, string name, List<Passage> passages)
        {
            Id = id;
            SizeX = sizeX;
            SizeY = sizeY;
            Name = name;
            Passages = passages;
        }

    }
}
