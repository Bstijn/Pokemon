using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ShopKeeper : Character, ISellBuy
    {
        public void BuyItem(Consumable consumable, int amount)
        {
            throw new NotImplementedException();
        }

        public void SellItem(Consumable consumable, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
