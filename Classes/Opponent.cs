using System;
using System.Collections.Generic;

namespace Classes
{
    public class Opponent : Character, IItemUser
    {
        //if opponent or gymleader is defeated they might give the player money or an item.
        public bool Defeated { get; private set; }
        public Opponent(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Item> inventory, List<Pokemon> pokemons, bool defeated) : base(name, id, gender, money, posX, posY, currentLocation, inventory, pokemons)
        {
            this.Defeated = defeated;
        }

        public void UseItemInBattle(Consumable consumable)
        {
            throw new NotImplementedException();
        }
    }
}
