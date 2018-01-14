using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;

namespace Classes.Repos
{
    public class LocationRepository
    {
        private ILocationContext context;


        public LocationRepository()
        {
            context = new LocationContext();
        }

        public Gymleader GetGymleader(int locationID)
        {
            object[] data = context.GetGymleader(locationID);
            //TODO: zet methodes voor location en pokemon hier
            return new Gymleader(data[0].ToString(), Convert.ToInt32(data[1]), data[2].ToString(), Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), Convert.ToInt32(data[5]), null/*dit wordt location*/, null/*GetInventory(Convert.ToInt32(data[1]))*/, null/*GetPokemon(data[1])*/, Convert.ToBoolean(data[6]));
        }

        public Nurse GetNurse(int locationID)
        {
            object[] data = context.GetNurse(locationID);
            // TODO: implementeer dit
            return null;
        }

        public ShopKeeper GetShopkeeper(int locationID)
        {
            object[] data = context.GetShopkeeper(locationID);
            // TODO: implementeer dit
            return null;
        }

        public List<Oppenent> GetOpponents(int locationID)
        {
            List<object[]> data = context.GetOpponents(locationID);
            List<Oppenent> oppenents = new List<Oppenent>();

            foreach (object[] row in data)
            {
                // TODO: implementeer dit
            }
            return oppenents;
        }

        public List<Bystander> GetBystanders(int locationID)
        {
            List<object[]> data = context.GetBystanders(locationID);
            List<Bystander> bystanders = new List<Bystander>();

            foreach (object[] row in data)
            {
                // TODO: implementeer dit
            }
            return bystanders;
        }

        public List<Passage> GetPassages(int locationID)
        {
            List<object[]> data = context.GetPassages(locationID);
            List<Passage> passages = new List<Passage>();

            foreach (object[] row in data)
            {
                // TODO: implementeer dit
            }

            return passages;
        }

        public List<Pokemon> GetEncounterablePokemon(int locationID)
        {
            List<object[]> data = context.GetEncounterablePokemon(locationID);
            List<Pokemon> pokemonAtLocation = new List<Pokemon>();

            foreach (object[] row in data)
            {
                object[] typeData = context.GetPokemonType(Convert.ToInt32(row[0]));
                Type type = new Type(Convert.ToInt32(typeData[0]), typeData[1].ToString());
                var level = new Random().Next(ConvertToInt32(row[24]), ConvertToInt32(row[25]));
                List<Move> pokemonMoves = GetPokedexPokemonMoves(Convert.ToInt32(row[0]), level);

                pokemonAtLocation.Add(new Pokemon(type, pokemonMoves, Convert.ToInt32(row[0]), row[1].ToString(), false,
                    level, ConvertToInt32(row[13]), ConvertToInt32(row[13]), 0,
                    ConvertToInt32(row[7]), ConvertToInt32(row[8]), ConvertToInt32(row[11]), ConvertToInt32(row[6]),
                    ConvertToInt32(row[15])));
            }
            return pokemonAtLocation;
        }

        private int ConvertToInt32(object value, int defaultvalue = 0)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return defaultvalue;
            }
        }

        public List<Move> GetPokemonMoves(int pokemonID)
        {
            List<object[]> data = context.GetPokemonMoves(pokemonID);
            List<Move> pokemonMoves = new List<Move>();

            foreach (object[] row in data)
            {
                pokemonMoves.Add(new Move(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]),
                    Convert.ToInt32(row[4]), row[5].ToString(), false, Convert.ToInt32(row[6]), Convert.ToInt32(row[7]), GetMoveType(Convert.ToInt32(row[0]))));
            }

            return pokemonMoves;
        }

        public List<Move> GetPokedexPokemonMoves(int pokemonID, int level)
        {
            List<object[]> data = context.GetPokedexPokemonMoves(pokemonID, level);
            List<Move> pokemonMoves = new List<Move>();

            foreach (object[] row in data)
            {
                pokemonMoves.Add(new Move(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]),
                    Convert.ToInt32(row[3]), row[4].ToString(), Convert.ToInt32(row[5]), GetMoveType(Convert.ToInt32(row[0]))));
            }

            return pokemonMoves;
        }

        public Type GetPokemonType(int pokemonID)
        {
            object[] data = context.GetPokemonType(pokemonID);

            return new Type(Convert.ToInt32(data[0]), data[1].ToString());
        }

        public Type GetMoveType(int moveID)
        {
            object[] data = context.GetMoveType(moveID);

            return new Type(Convert.ToInt32(data[0]), data[1].ToString());
        }

        public List<Item> GetInventory(int characterID)
        {
            List<object[]> data = context.GetInventory(characterID);
            List<Item> inventoryItems = new List<Item>();

            foreach (Revive revive in GetRevives(characterID))
            {
                inventoryItems.Add(revive);
            }
            foreach (Potion potion in GetPotions(characterID))
            {
                inventoryItems.Add(potion);
            }
            foreach (Pokeball pokeball in GetPokeballs(characterID))
            {
                inventoryItems.Add(pokeball);
            }
            return inventoryItems;
        }

        public List<Revive> GetRevives(int characterID)
        {
            List<object[]> data = context.GetRevives(characterID);
            List<Revive> revives = new List<Revive>();

            foreach (object[] row in data)
            {
                for (int i = 0; i < Convert.ToInt32(data[5]); i++)
                {
                    revives.Add(new Revive(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), row[3].ToString(), Convert.ToInt32(row[4])));
                }

            }
            return revives;
        }

        public List<Potion> GetPotions(int characterID)
        {
            List<object[]> data = context.GetPotions(characterID);
            List<Potion> potions = new List<Potion>();

            foreach (object[] row in data)
            {
                for (int i = 0; i < Convert.ToInt32(data[5]); i++)
                {
                    potions.Add(new Potion(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), row[3].ToString(), Convert.ToInt32(row[4])));
                }
            }
            return potions;
        }

        public List<Pokeball> GetPokeballs(int characterID)
        {
            List<object[]> data = context.GetPokeballs(characterID);
            List<Pokeball> pokeballs = new List<Pokeball>();

            foreach (object[] row in data)
            {
                for (int i = 0; i < Convert.ToInt32(data[5]); i++)
                {
                    pokeballs.Add(new Pokeball(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), row[3].ToString(), Convert.ToInt32(row[4])));
                }
            }
            return pokeballs;
        }

        public decimal GetEncounterChance(int locationID)
        {
            object[] data = context.GetEncounterChance(locationID);

            return Convert.ToDecimal(data[0]);
        }

        //TODO: Laura, fix dit
        public Location GetCurrentLocation(int locationID)
        {
            //atm alleen routes
            object[] data = context.GetCurrentLocation(locationID);
            Location location = new Route(Convert.ToInt32(data[0]), data[1].ToString(), GetPassages(locationID),Convert.ToInt32(data[4]), Convert.ToInt32(data[5]), Convert.ToInt32(data[3]), GetEncounterablePokemon(locationID));
            return location;
        }

        public Passage GetPassageByLocationAndCoords(int locationID, int x, int y)
        {
            object[] data = context.GetPassageByLocationAndCoords(locationID, x, y);
            Passage passage = new Passage(Convert.ToInt32(data[2]), Convert.ToInt32(data[5]), Convert.ToInt32(data[6]), Convert.ToInt32(data[7]), Convert.ToInt32(data[8]), GetCurrentLocation(Convert.ToInt32(data[4])));
            return passage;
        }
    }
}
