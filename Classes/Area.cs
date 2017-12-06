﻿using System.Collections.Generic;

namespace Classes
{
    public abstract class Area : Location
    {

        public int MinLevel { get; private set; }
        public int MaxLevel { get; private set; }
        public decimal EncounterChance { get; private set; }
        public List<Pokemon> AvailablePokemons { get; private set; }
        public Area(int id, string name, List<Passage> passages, int minLevel, int maxLevel, decimal encounterChance, List<Pokemon> availablePokemons) : base(id, name, passages)
        {
            MinLevel = minLevel;
            MaxLevel = maxLevel;
            EncounterChance = encounterChance;
            AvailablePokemons = availablePokemons;
        }

    }
}
