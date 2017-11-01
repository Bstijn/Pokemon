using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface ISellBuy
    {
        void BuyItem(Consumable consumable, int amount);
        void SellItem(Consumable consumable, int amount);
    }
}
