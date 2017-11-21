using System;
using System.Collections.Generic;

namespace Classes
{
    public class Gymleader : Character, IItemUser
    {
        //if opponent or gymleader is defeated they might give the player money or an item.
        public Boolean Defeated { get; private set; }

        public Gymleader(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Item> inventory, List<Pokemon> pokemons, bool defeated) : base(name, id, gender, money, posX, posY, currentLocation, inventory, pokemons)
        {
            this.Defeated = defeated;
        }


        public void UseItemInBattle(Consumable consumable)
        {
            throw new NotImplementedException();
        }

        public Badge GiveBadge()
        {
            throw new NotImplementedException();
        } 
    }
}
