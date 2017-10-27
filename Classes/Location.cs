using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Location
    {
        public int Id { get; private set; }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public string Name { get; private set; }
        public List<Passage> Passages { get; private set; }
    }
}
