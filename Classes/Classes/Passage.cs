using System;

namespace Classes.Classes
{
    public class Passage
    {
        public int Id { get; private set; }
        public int FromX { get; private set; }
        public int FromY { get; private set; }
        public int ToX { get; private set; }
        public int ToY { get; private set; }
        public Location ToLocation { get; private set; }
        public void EnternewLocation()//gebruikt waarschijnlijk ToLocation
        {
            throw new NotImplementedException();
        }
    }
}
