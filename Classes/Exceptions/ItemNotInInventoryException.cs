using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Exceptions
{
    public class ItemNotInInventoryException: Exception
    {
        public ItemNotInInventoryException() : base("The item u want to use is not in your inventory")
        {

        }
    }
}
