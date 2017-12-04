using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Repos
{
    public class CharacterRepository
    {
        private ICharacterContext context;

        public CharacterRepository()
        {
            context = new CharacterContext();
        }

        private List<Revive> GetRevives(int characterID)
        {
            List<object[]> data = context.GetRevives(characterID);
            List<Revive> revives = new List<Revive>();

            foreach (object[] row in data)
            {
                revives.Add(new Revive(Convert.ToInt32(data[0]), data[1].ToString(), Convert.ToInt32(data[2]), data[3].ToString(), Convert.ToInt32(data[4])));
            }
            

            return revives;
        }

        private List<Potion> GetPotions(int characterID)
        {
            List<object[]> data = context.GetPotions(characterID);
            List<Potion> potions = new List<Potion>();

            foreach (object[] row in data)
            {
                potions.Add(new Potion(Convert.ToInt32(data[0]), data[1].ToString(), Convert.ToInt32(data[2]), data[3].ToString(), Convert.ToInt32(data[4])));
            }

            return potions;
        }

        private List<Pokeball> GetPokeballs(int characterID)
        {
            List<object[]> data = context.GetPokeballs(characterID);
            List<Pokeball> pokeballs = new List<Pokeball>();

            foreach (object[] row in data)
            {
                pokeballs.Add(new Pokeball(Convert.ToInt32(data[0]), data[1].ToString(), Convert.ToInt32(data[2]), data[3].ToString(), Convert.ToInt32(data[4])));
            }

            return pokeballs;
        }

        private List<Badge> GetBadges(int characterID)
        {
            List<object[]> data = context.GetBadges(characterID);
            List<Badge> badges = new List<Badge>();

            foreach (object[] row in data)
            {
                badges.Add(new Badge(Convert.ToInt32(data[0]), data[1].ToString(), data[2].ToString()));
            }

            return badges;
        }

        private List<KeyItem> GetKeyItems(int characterID)
        {
            List<object[]> data = context.GetKeyItems(characterID);
            List<KeyItem> keyItems = new List<KeyItem>();

            foreach (object[] row in data)
            {
                keyItems.Add(new KeyItem(Convert.ToInt32(data[0]), data[1].ToString(), data[2].ToString(), Convert.ToBoolean(data[3])));
            }

            return keyItems;
        }

        public List<Pokemon> GetPokemonFromParty(int characterID)
        {
            List<object[]> data = context.GetPokemonFromParty(characterID);
            List<Pokemon> pokemonInParty = new List<Pokemon>();

            foreach (object[] row in data)
            {
                object[] typeData = context.GetPokemonType(Convert.ToInt32(row[0]));
                Type type = new Type(Convert.ToInt32(typeData[0]), typeData[1].ToString());
                List<Move> pokemonMoves = GetPokemonMoves(Convert.ToInt32(row[0]));

                pokemonInParty.Add(new Pokemon(type, pokemonMoves, Convert.ToInt32(data[0]), data[1].ToString(), Convert.ToBoolean(data[2]),
                    Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), Convert.ToInt32(data[5]), Convert.ToInt32(data[6]),
                    Convert.ToInt32(data[7]), Convert.ToInt32(data[8]), Convert.ToInt32(data[9]), Convert.ToInt32(data[10]),
                    Convert.ToInt32(data[11])));
            }
            return pokemonInParty;
        }

        public List<Dialogue> GetDialogues(int characterID)
        {
            List<object[]> data = context.GetDialogues(characterID);
            List<Dialogue> dialogues = new List<Dialogue>();

            foreach (object[] row in data)
            {
                dialogues.Add(new Dialogue(Convert.ToInt32(data[0]), data[1].ToString()));
            }

            return dialogues;
        }

        public List<Move> GetPokemonMoves(int pokemonID)
        {
            List<object[]> data = context.GetPokemonMoves(pokemonID);
            List<Move> pokemonMoves = new List<Move>();

            foreach (object[] row in data)
            {
                pokemonMoves.Add(new Move(Convert.ToInt32(data[0]), data[1].ToString(), Convert.ToInt32(data[2]), Convert.ToInt32(data[3]),
                    Convert.ToInt32(data[4]), data[5].ToString(), Convert.ToBoolean(data[6]), Convert.ToInt32(data[7]), Convert.ToInt32(data[8])));
            }

            return pokemonMoves;
        }

        public Type GetPokemonType(int pokemonID)
        {
            object[] data = context.GetPokemonType(pokemonID);

            return new Type(Convert.ToInt32(data[0]), data[1].ToString());
        }


        public List<Item> GetInventory(int characterID)
        {
            List<Item> inventory = new List<Item>();

            foreach (Potion potion in GetPotions(characterID))
                inventory.Add(potion);
            foreach (Revive revive in GetRevives(characterID))
                inventory.Add(revive);
            foreach (Pokeball pokeball in GetPokeballs(characterID))
                inventory.Add(pokeball);
            foreach (KeyItem keyItem in GetKeyItems(characterID))
                inventory.Add(keyItem);
            foreach (Badge badge in GetBadges(characterID))
                inventory.Add(badge);

            return inventory;
        } 

        public Location GetCurrentLocation(int locationID)
        {
            string locationType = context.GetLocationType(locationID);
            Location location;
            switch (locationType)
            {
                //case "pokemart":
                //    location = new Pokemart()
                //    break;
                //case "gym":
                //    location = new Gym()
                //    break;
                //case "pokecenter":
                //    location = new Pokecenter()
                //    break;
                //case "enemyhq":
                //    location = new EnemyHQ()
                //    break;
                //case "city":
                //    location = new City()
                //    break;
                //case "cave":
                //    location = new Cave()
                //    break;
                //case "route":
                //    location = new Route()
                //    break;
            }

            //return new Location(Convert.ToInt32(data[0]), data[1].ToString()); 
            return null;

        public void InserIntro(int pokemonID, string naam, string gender)
        {
            context.InsterIntro(pokemonID, naam, gender);

        }
    }
}
