using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;

namespace Classes.Repos
{
    public class PokemartRepository
    {
        private IPokemartContext context;

        public PokemartRepository()
        {
            context = new PokemartContext();
        }

        public List<Revive> GetRevives(int pokemartID)
        {
            List<object[]> data = context.GetRevives(pokemartID);
            List<Revive> revives = new List<Revive>();

            foreach (object[] row in data)
            {
                revives.Add(new Revive(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), row[3].ToString(), Convert.ToInt32(row[4])));
            }

            return revives;
        }

        public List<Potion> GetPotions(int pokemartID)
        {
            List<object[]> data = context.GetRevives(pokemartID);
            List<Potion> potions = new List<Potion>();

            foreach (object[] row in data)
            {
                potions.Add(new Potion(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), row[3].ToString(), Convert.ToInt32(row[4])));
            }

            return potions;
        }

        public List<Pokeball> GetPokeballs(int pokemartID)
        {
            List<object[]> data = context.GetRevives(pokemartID);
            List<Pokeball> pokeballs = new List<Pokeball>();

            foreach (object[] row in data)
            {
                pokeballs.Add(new Pokeball(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), row[3].ToString(), Convert.ToDecimal(row[4])));
            }

            return pokeballs;
        }
    }
}
