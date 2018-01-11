using System;
using System.Collections.Generic;

namespace Classes
{
    public abstract class Area : Location
    {
        public int MinLevel { get; private set; }
        public int MaxLevel { get; private set; }
        public decimal EncounterChance { get; private set; }
        public List<Pokemon> AvailablePokemons { get; private set; }
        private Random random;

        public Area(int id, string name, List<Passage> passages, int minLevel, int maxLevel, decimal encounterChance, List<Pokemon> availablePokemons) : base(id, name, passages)
        {
            MinLevel = minLevel;
            MaxLevel = maxLevel;
            EncounterChance = encounterChance;
            AvailablePokemons = repo.GetEncounterablePokemon(id);
            random = new Random();
        }

        public Pokemon GenerateBattle()
        {
            return AvailablePokemons[random.Next(AvailablePokemons.Count - 1)];
        }
    }
}
