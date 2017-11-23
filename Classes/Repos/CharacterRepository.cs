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

        public CharacterRepository(ICharacterContext context)
        {
            context = new CharacterContext();
        }

        public List<Revive> GetRevives(int characterID)
        {
            List<object[]> data = context.GetRevives(characterID);
            List<Revive> revives = new List<Revive>();

            foreach (object[] row in data)
            {
                revives.Add(new Revive(Convert.ToInt32(data[0]), data[1].ToString(), Convert.ToInt32(data[2]), data[3].ToString(), Convert.ToInt32(data[4])));
            }
            

            return revives;
        }

        public List<Potion> GetPotions(int characterID)
        {
            List<object[]> data = context.GetPotions(characterID);
            List<Potion> potions = new List<Potion>();

            foreach (object[] row in data)
            {
                potions.Add(new Potion(Convert.ToInt32(data[0]), data[1].ToString(), Convert.ToInt32(data[2]), data[3].ToString(), Convert.ToInt32(data[4])));
            }

            return potions;
        }

        public List<Pokeball> GetPokeballs(int characterID)
        {
            List<object[]> data = context.GetPokeballs(characterID);
            List<Pokeball> pokeballs = new List<Pokeball>();

            foreach (object[] row in data)
            {
                pokeballs.Add(new Pokeball(Convert.ToInt32(data[0]), data[1].ToString(), Convert.ToInt32(data[2]), data[3].ToString(), Convert.ToInt32(data[4])));
            }

            return pokeballs;
        }

        public List<Badge> GetBadges(int characterID)
        {
            List<object[]> data = context.GetBadges(characterID);
            List<Badge> badges = new List<Badge>();

            foreach (object[] row in data)
            {
                badges.Add(new Badge(Convert.ToInt32(data[0]), data[1].ToString(), data[2].ToString()));
            }

            return badges;
        }

        public List<KeyItem> GetKeyItems(int characterID)
        {
            List<object[]> data = context.GetKeyItems(characterID);
            List<KeyItem> keyItems = new List<KeyItem>();

            foreach (object[] row in data)
            {
                keyItems.Add(new KeyItem(Convert.ToInt32(data[0]), data[1].ToString(), data[2].ToString(), Convert.ToBoolean(data[3])));
            }

            return keyItems;
        }

        public List<Pokemon> GetPokemon(int characterID)
        {
            List<object[]> data = context.GetPokemon(characterID);
            List<Pokemon> pokemon = new List<Pokemon>();

            foreach (object[] row in data)
            {
                //pokemon.Add(new Pokemon(Convert.ToInt32(data[0]), data[3].ToString(), Convert.ToInt32(data[1]), data[2].ToString(), Convert.ToBoolean(data[4])));
            }

            return pokemon;
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
    }
}
