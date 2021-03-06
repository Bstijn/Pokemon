﻿using System.Collections.Generic;

namespace Classes.Classes
{
    public abstract class Area : Location
    {
        public int MinLevel { get; private set; }
        public int MaxLevel { get; private set; }
        public decimal EncounterChance { get; private set; }
        private List<Pokemon> availablePokemons;

        protected Area(int id, int sizeX, int sizeY, string name, List<Passage> passages, int minLevel, int maxLevel, decimal encounterChance, List<Pokemon> availablePokemons) : base(id, sizeX, sizeY, name, passages)
        {
            MinLevel = minLevel;
            MaxLevel = maxLevel;
            EncounterChance = encounterChance;
            this.availablePokemons = availablePokemons;
        }
    }
}
