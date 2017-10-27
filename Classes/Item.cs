using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Item
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public string Description { get; private set; }

    }
}
