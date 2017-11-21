using System;

namespace Classes
{
    public class Passage
    {

        public int Id { get; private set; }
        public int FromX { get; private set; }
        public int FromY { get; private set; }
        public int ToX { get; private set; }
        public int ToY { get; private set; }
        public Location ToLocation { get; private set; }
        public Passage(int id, int fromX, int fromY, int toX, int toY, Location toLocation)
        {
            Id = id;
            FromX = fromX;
            FromY = fromY;
            ToX = toX;
            ToY = toY;
            ToLocation = toLocation;
        }
        public void EnternewLocation()//gebruikt waarschijnlijk ToLocation
        {
            throw new NotImplementedException();
        }
    }
}
