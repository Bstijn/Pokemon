using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Exceptions
{
    public class NotEnoughItemsToSellExceptions : Exception

    {
        public NotEnoughItemsToSellExceptions() : base("You do not have enough items. you can not sell more item than there are in your inventory")
        {

        }
    }
}
