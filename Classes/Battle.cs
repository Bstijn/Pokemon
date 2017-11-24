using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Classes.Exceptions;

namespace Classes
{
    public class Battle
    {

        public Player Player { get; private set; }
        public Pokemon WildPokemon { get; private set; }
        public Opponent Opponent { get; private set; }
        public int FleeAttempts { get; private set; }

        public Battle(Player player,Pokemon wildPokemon)
        {
            this.Player = player;
            this.WildPokemon = wildPokemon;
        }

        public Battle(Player player, Opponent opponent)
        {
            this.Player = player;
            this.Opponent = opponent;
        }

        public bool Flee(Pokemon pokemon)
        {
            if (WildPokemon == null)
                throw new CannotFleeTrainerBattleException();

            FleeAttempts++;
            return pokemon.TryFlee(WildPokemon.Speed, FleeAttempts);
        }

        public bool UseItem(Consumable consumable, Pokemon targetPokemon)
        {
            //TODO Bij items 1 van inventory af als deze gebruikt wordt
            if (consumable.GetType() == typeof(Pokeball))
            {
                if (consumable.Use(targetPokemon))
                    return true;
                return false;
            }

            var selectedPokemon = Player.Pokemons.First(p => targetPokemon.Id == p.Id);
            if (consumable.GetType() == typeof(Revive))
            {
                var revive = (Revive) consumable;
                selectedPokemon.Revive(revive.Percentage);
                return true;
            }

            if (consumable.GetType() == typeof(Potion))
            {
                var potion = (Potion) consumable;
                selectedPokemon.HealByPotion(potion);
                return true;
            }
            return false;
        }

        /* 
         * TODO's Algemene battle
         * Experience/Gold na gevecht()
         * Pokemon Vangen()
         * Wie valt als eerste aan!
        */


    }
}
