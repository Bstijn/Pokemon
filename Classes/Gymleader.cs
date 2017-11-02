using System;
using System.Collections.Generic;

namespace Classes
{
    public class Gymleader : Character, IItemUser
    {
        public Boolean Defeated { get; private set; }

        public void UseItemInBattle(Consumable consumable)
        {
            throw new NotImplementedException();
        }

        public void GiveBadge(Badge badge)
        {
            throw new NotImplementedException();
        }

        public Gymleader(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Possesion> inventory, List<Pokemon> partyPokemon) : base(name, id, gender, money, posX, posY, currentLocation, inventory, partyPokemon)
        {
        }
    }
}
