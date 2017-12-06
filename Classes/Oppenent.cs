using System;
using System.Collections.Generic;
using Classes.Exceptions;

namespace Classes
{
    public class Oppenent : Character
    {
        //if opponent or gymleader is defeated they might give the player money or an item.
        public bool Defeated { get; private set; }
        public Oppenent(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Possesion> inventory, List<Pokemon> pokemons, bool defeated) : base(name, id, gender, money, posX, posY, currentLocation, inventory, pokemons)
        {
            this.Defeated = defeated;
        }
    }
}
