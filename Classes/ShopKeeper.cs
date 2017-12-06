using System;
using System.Collections.Generic;

namespace Classes
{
    public class ShopKeeper : Character
    {
        public ShopKeeper(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Possesion> inventory, List<Pokemon> pokemons) : base(name, id, gender, money, posX, posY, currentLocation, inventory, pokemons)
        {
        }
    }
}
