using System;
using System.Collections.Generic;
using Classes.Exceptions;

namespace Classes
{
    public class Gymleader : Character
    {
        //if opponent or gymleader is defeated they might give the player money or an item.
        public bool Defeated { get; private set; }

        public Gymleader(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Possesion> inventory, List<Pokemon> pokemons, bool defeated) : base(name, id, gender, money, posX, posY, currentLocation, inventory, pokemons)
        {
            Defeated = defeated;
        }



        public Badge Lose()//Before GiveBadge now also switches defeated to true.
        {
            Defeated = true;
            Possesion ToBeRemoved = null;
            foreach (Possesion i in Inventory)
            {
                if (i.Item is Badge)
                {
                    ToBeRemoved = i; break;
                }
            }
            if (ToBeRemoved != null)
            {
                Inventory.Remove(ToBeRemoved);
                return ToBeRemoved.Item as Badge;
            }
            else
            {
                throw new GymLeaderHasNoBadgeException();
            }
        }
    }
}
