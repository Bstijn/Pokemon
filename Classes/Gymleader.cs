using System;
using System.Collections.Generic;
using Classes.Exceptions;

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



        public Badge GiveBadge()
        {
            throw new NotImplementedException();
        }

        public void UseItemInBattle(Pokemon targetForItem, Consumable consumable)
        {
            foreach (Consumable consInInv in Inventory)
            {
                if (consInInv.Id == consumable.Id)
                {
                    consumable = consInInv;
                    break;
                }
            }
            if (!Inventory.Contains(consumable))
            {
                throw new ItemNotInInventoryException();
            }

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
            Inventory.Remove(consumable);
        }
    }
}
