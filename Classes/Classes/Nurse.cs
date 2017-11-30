using System;
using System.Collections.Generic;

namespace Classes.Classes
{
    public class Nurse : Character
    {
        public void Heal()
        {
            throw new NotImplementedException();
        }

        public Nurse(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Item> inventory, List<Pokemon> partyPokemon) : base(name, id, gender, money, posX, posY, currentLocation, inventory, partyPokemon)
        {
        }
    }
}
