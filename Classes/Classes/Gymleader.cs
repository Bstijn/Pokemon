using System;
using System.Collections.Generic;

namespace Classes.Classes
{
    public class Gymleader : Character, IItemUser
    {
        public bool Defeated { get; private set; }

        public Gymleader(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Item> inventory, List<Pokemon> partyPokemon, bool defeated) : base(name, id, gender, money, posX, posY, currentLocation, inventory, partyPokemon)
        {
            Defeated = false;
        }

        public void UseItemInBattle(Consumable consumable)
        {
            throw new NotImplementedException();
        }

        public void GiveBadge(Badge badge)
        {
            throw new NotImplementedException();
        }
    }
}
