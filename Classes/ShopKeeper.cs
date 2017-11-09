using System;
using System.Collections.Generic;

namespace Classes
{
    public class ShopKeeper : Character, ISellBuy
    {
        public ShopKeeper(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Item> inventory, List<Pokemon> partyPokemon) : base(name, id, gender, money, posX, posY, currentLocation, inventory, partyPokemon)
        {
        }

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
