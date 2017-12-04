using System;
using System.Collections.Generic;

namespace Classes
{
    public class Nurse : Character
    {

        public void Heal(List<Pokemon> pokemon)
        {
            foreach(Pokemon p in pokemon)
            {
                p.Revive(0);
                p.Heal(p.MaxHp - p.CurrentHp);
            }
        }
        public Nurse(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Possesion> inventory, List<Pokemon> pokemons) : base(name, id, gender, money, posX, posY, currentLocation, inventory, pokemons)
        {
        }
    }
}
