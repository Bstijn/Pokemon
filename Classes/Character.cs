using Classes.Repos;
using DAL_Remake.SQLContexts;
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
        public List<Possesion> Inventory { get; protected set; }
        public List<Pokemon> Pokemons { get; private set; }

        protected LocationRepository locationRepo;


        public Character(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Possesion> inventory, List<Pokemon> pokemons)
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

        public Character(string name, int id, string gender, int money, int posX, int posY, int locationID)
        {
            Name = name;
            Id = id;
            Gender = gender;
            Money = money;
            PosX = posX;
            PosY = posY;
            //TODO Roberto look at this
            locationRepo = new LocationRepository(new LocationContext());
            CurrentLocation = locationRepo.GetCurrentLocation(locationID);
            //Inventory = repo.GetInventory(id);
            //Pokemons = repo.GetPokemonFromParty(id);
        }

        public Location GetCurrentLocation()
        {
            return CurrentLocation;
        }

        public void SetCurrentLocation(Location location)
        {
            location = CurrentLocation;
        }

        public List<Possesion> GetInventory()
        {
            return Inventory;
        }

        public void SetInventory(List<Possesion> inventory)
        {
           Inventory = inventory;
        }

        public List<Pokemon> GetPokemons()
        {
            return Pokemons;
        }

        public void SetPokemons(List<Pokemon> pokemons)
        {
            Pokemons = pokemons;
        }

        public string Talk(Dialogue dialogue)
        {
            throw new NotImplementedException();
        }
    }
}
