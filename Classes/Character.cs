using Classes.Repos;
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
        private Location currentLocation;
        private List<Item> inventory;
        private List<Pokemon> pokemons;
        private CharacterRepository repo;

        public Character(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Item> inventory, List<Pokemon> pokemons)
        {
            Name = name;
            Id = id;
            Gender = gender;
            Money = money;
            PosX = posX;
            PosY = posY;
            this.currentLocation = currentLocation;
            this.inventory = inventory;
            this.pokemons = pokemons;
        }

        public Character(string name, int id, string gender, int money, int posX, int posY)
        {
            Name = name;
            Id = id;
            Gender = gender;
            Money = money;
            PosX = posX;
            PosY = posY;
            this.currentLocation = repo.GetCurrentLocation(id);
            this.inventory = repo.GetInventory(id);
            this.pokemons = repo.GetPokemonFromParty(id);
        }

        public Location GetCurrentLocation()
        {
            return currentLocation;
        }

        public void SetCurrentLocation(Location location)
        {
            location = currentLocation;
        }

        public List<Item> GetInventory()
        {
            return inventory;
        }

        public void SetInventory(List<Item> inventory)
        {
            this.inventory = inventory;
        }

        public List<Pokemon> GetPokemons()
        {
            return pokemons;
        }

        public void SetPokemons(List<Pokemon> pokemons)
        {
            this.pokemons = pokemons;
        }

        public string Talk(Dialogue dialogue)
        {
            throw new NotImplementedException();
        }
    }
}
