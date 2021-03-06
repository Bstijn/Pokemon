﻿using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;

namespace Classes.Repos
{
    public class CharacterRepository
    {
        private ICharacterContext context;

        public CharacterRepository()
        {
            context = new CharacterContext();
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

        public List<Pokemon> GetPokemonFromParty(int characterID)
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

        public List<Dialogue> GetDialogues(int characterID)
        {
            List<object[]> data = context.GetDialogues(characterID);
            List<Dialogue> dialogues = new List<Dialogue>();

            foreach (object[] row in data)
            {
                dialogues.Add(new Dialogue(Convert.ToInt32(row[0]), row[1].ToString()));
            }

            return dialogues;
        }

        public void SavePokemons(int level, int pokedexId, int? inparty)
        {
            context.InsertPokemon(level, pokedexId, inparty);
        }

        public List<Move> GetPokemonMoves(int pokemonID)
        {
            List<object[]> data = context.GetPokemonMoves(pokemonID);
            List<Move> pokemonMoves = new List<Move>();

            foreach (object[] row in data)
            {
                pokemonMoves.Add(new Move(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]),
                    Convert.ToInt32(row[4]), row[5].ToString(), false, Convert.ToInt32(row[6]), Convert.ToInt32(row[7]), GetPokemonType(pokemonID)));
            }

            return pokemonMoves;
        }

        public Type GetPokemonType(int pokemonID)
        {
            object[] data = context.GetPokemonType(pokemonID);

            return new Type(Convert.ToInt32(data[0]), data[1].ToString());
        }


        public List<Possesion> GetInventory(int characterID)
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

        public Location GetCurrentLocation(int locationID)
        {
            string locationType = context.GetLocationType(locationID);
            Location location;
            switch (locationType)
            {
                // TODO: maak deze switch af
                case "pokemart":
                    //location = new Pokemart();
                    break;
                case "gym":
                    //location = new Gym();
                    break;
                case "pokecenter":
                    //location = new Pokecenter();
                    break;
                case "enemyhq":
                    //location = new EnemyHQ();
                    break;
                case "city":
                    //location = new City();
                    break;
                case "cave":
                    //location = new Cave();
                    break;
                case "route":
                    //location = new Route();
                    break;
            }
            //return location; 
            return null;
        }

        internal void UpdatePokemons(List<Pokemon> pokemons)
        {
            foreach(Pokemon pokemon in pokemons)
            {
                context.UpdatePokemon(pokemon);
                foreach(Move move in pokemon.GetMoves())
                {
                    context.UpdateMove(move, pokemon);
                }
            }
        }

        public void InsertIntro(int pokemonID, string naam, string gender)
        {
            context.InsertIntro(pokemonID, naam, gender);
        }
        public void InsertPokemon(int lvl, int pokedexPokemonId,int? Partyid)
        {
            context.InsertPokemon(lvl, pokedexPokemonId, Partyid);
        }
    }
}
