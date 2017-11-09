using System;
using System.Collections.Generic;


namespace Classes
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public string Gender { get; private set; }
        public int Money { get; private set; }
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        private Location currentLocation;
        private List<Item> inventory;
        private List<Pokemon> partyPokemon;

        protected Character(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Item> inventory, List<Pokemon> partyPokemon)
        {
            Name = name;
            Id = id;
            Gender = gender;
            Money = money;
            PosX = posX;
            PosY = posY;
            this.currentLocation = currentLocation;
            this.inventory = inventory;
            this.partyPokemon = partyPokemon;
        }

        public string Talk(Dialogue dialogue)
        {
            throw new NotImplementedException();
        }
    }
}
