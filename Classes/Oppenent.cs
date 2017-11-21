using System;
using System.Collections.Generic;

namespace Classes
{
    public class Oppenent : Character, IItemUser
    {
        //if opponent or gymleader is defeated they might give the player money or an item.
        public bool Defeated { get; private set; }
        public Oppenent(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Item> inventory, List<Pokemon> pokemons, bool defeated) : base(name, id, gender, money, posX, posY, currentLocation, inventory, pokemons)
        {
            this.Defeated = defeated;
        }

        public void UseItemInBattle(Pokemon targetForItem, Consumable consumable)
        {
            if (consumable is Potion)
            {
                targetForItem.Heal((consumable as Potion).HealAmount);
            }
            else if (consumable is Revive)
            {
                targetForItem.Revive((consumable as Revive).Percentage);
            }
            else if (consumable is Pokeball)
            {
                throw new NotImplementedException();
            }
        }
    }
}
