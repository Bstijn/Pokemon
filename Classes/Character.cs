using System;
using System.Collections.Generic;


namespace Classes
{
    public abstract class Character
    {

        public string Name { get; private set; }
        public int Id { get; private set; }
        public string Gender { get; private set; }
        public int Money { get; protected set; }
        public int PosX { get; protected set; }
        public int PosY { get; protected set; }
        public Location CurrentLocation { get; protected set; }
        public List<Item> Inventory { get; protected set; }
        public List<Pokemon> Pokemons { get; protected set; }

        public Character(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Item> inventory, List<Pokemon> pokemons)
        {
            Name = name;
            Id = id;
            Gender = gender;
            Money = money;
            PosX = posX;
            PosY = posY;
            CurrentLocation = currentLocation;
            Inventory = inventory;
            Pokemons = pokemons;
        }
        
        public string Talk(Dialogue dialogue)
        {
            throw new NotImplementedException();
        }

       
    }
}
