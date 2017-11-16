using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Exceptions
{
    public class NotEnoughConsumablesToSellException : Exception
    {
        public NotEnoughConsumablesToSellException() :base("the amount of the item you want to sell is too high")
        {

        }
    }
}
