using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;

namespace Classes.Repos
{
    public class PlayerRepository
    {
        private IPlayerContext context;

        public PlayerRepository()
        {
            context = new PlayerContext();
        }

        public void Save()
        {
            context.Save();
        }

        public Player Load()
        {
            object[] data = context.Load();
            Player player = new Player(data[0].ToString(), (int)data[1], data[2].ToString(), (int)data[3], (int)data[4], (int)data[5], (int)data[6], (int)data[7], (int)data[8]);
            player.SetPokemons(GetPokemonFromParty(player.Id));
            player.SetInventory(GetInventory(player.Id));

            return player;
        }

        private List<Pokemon> GetPokemonFromParty(int characterID)
        {
            List<object[]> data = context.GetPokemonFromParty(characterID);
            List<Pokemon> pokemonInParty = new List<Pokemon>();

            foreach (object[] row in data)
            {
                object[] typeData = context.GetPokemonType(Convert.ToInt32(row[0]));
                Type type = new Type(Convert.ToInt32(typeData[0]), typeData[1].ToString());
                List<Move> pokemonMoves = GetPokemonMoves(Convert.ToInt32(row[0]));

                pokemonInParty.Add(new Pokemon(type, pokemonMoves, Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToBoolean(row[2]),
                    Convert.ToInt32(row[3]), Convert.ToInt32(row[4]), Convert.ToInt32(row[5]), Convert.ToInt32(row[6]),
                    Convert.ToInt32(row[7]), Convert.ToInt32(row[8]), Convert.ToInt32(row[9]), Convert.ToInt32(row[10]),
                    Convert.ToInt32(row[11])));
            }
            return pokemonInParty;
        }

        private List<Move> GetPokemonMoves(int pokemonID)
        {
            List<object[]> data = context.GetPokemonMoves(pokemonID);
            List<Move> pokemonMoves = new List<Move>();

            foreach (object[] row in data)
            {
                pokemonMoves.Add(new Move(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]),
                    Convert.ToInt32(row[4]), row[5].ToString(), Convert.ToBoolean(row[6]), Convert.ToInt32(row[7]), Convert.ToInt32(row[8]), GetPokemonType(pokemonID)));
            }

            return pokemonMoves;
        }

        private Type GetPokemonType(int pokemonID)
        {
            object[] data = context.GetPokemonType(pokemonID);

            return new Type(Convert.ToInt32(data[0]), data[1].ToString());
        }


        private List<Possesion> GetInventory(int characterID)
        {
            List<Possesion> inventory = new List<Possesion>();

            foreach (Possesion potion in GetPotions(characterID))
                inventory.Add(potion);
            foreach (Possesion revive in GetRevives(characterID))
                inventory.Add(revive);
            foreach (Possesion pokeball in GetPokeballs(characterID))
                inventory.Add(pokeball);
            foreach (Possesion keyItem in GetKeyItems(characterID))
                inventory.Add(keyItem);
            foreach (Possesion badge in GetBadges(characterID))
                inventory.Add(badge);

            return inventory;
        }

        private List<Possesion> GetRevives(int characterID)
        {
            List<object[]> data = context.GetRevives(characterID);
            List<Possesion> revives = new List<Possesion>();

            foreach (object[] row in data)
            {
                revives.Add(new Possesion((int)row[5], new Revive(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), row[3].ToString(), Convert.ToInt32(row[4]))));
            }


            return revives;
        }

        private List<Possesion> GetPotions(int characterID)
        {
            List<object[]> data = context.GetPotions(characterID);
            List<Possesion> potions = new List<Possesion>();

            foreach (object[] row in data)
            {
                potions.Add(new Possesion((int)row[5], new Potion(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), row[3].ToString(), Convert.ToInt32(row[4]))));
            }

            return potions;
        }

        private List<Possesion> GetPokeballs(int characterID)
        {
            List<object[]> data = context.GetPokeballs(characterID);
            List<Possesion> pokeballs = new List<Possesion>();

            foreach (object[] row in data)
            {
                pokeballs.Add(new Possesion((int)row[5], new Pokeball(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), row[3].ToString(), Convert.ToInt32(row[4]))));
            }

            return pokeballs;
        }

        private List<Possesion> GetBadges(int characterID)
        {
            List<object[]> data = context.GetBadges(characterID);
            List<Possesion> badges = new List<Possesion>();

            foreach (object[] row in data)
            {
                badges.Add(new Possesion((int)row[3], new Badge(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString())));
            }

            return badges;
        }

        private List<Possesion> GetKeyItems(int characterID)
        {
            List<object[]> data = context.GetKeyItems(characterID);
            List<Possesion> keyItems = new List<Possesion>();

            foreach (object[] row in data)
            {
                keyItems.Add(new Possesion(Convert.ToInt32(row[4]), new KeyItem(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), Convert.ToBoolean(row[3]))));
            }

            return keyItems;
        }
    }
}
