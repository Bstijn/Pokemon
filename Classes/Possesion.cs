using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Classes
{
    public class Possesion
    {
        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public Item Item { get; private set; }

        public void ItemUsed()
        {
            Quantity--;
        }
    }
}
