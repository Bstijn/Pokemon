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
        public Oppenent Opponent { get; private set; }
        public int FleeAttempts { get; private set; }

        public Battle(Player player,Pokemon wildPokemon)
        {
            this.Player = player;
            this.WildPokemon = wildPokemon;
        }

        public Battle(Player player, Oppenent opponent)
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
            return Player.UseItemInBattle(consumable, targetPokemon);
        }

        /* 
         * TODO's Algemene battle
         * Experience/Gold na gevecht()
         * Pokemon Vangen()
         * Wie valt als eerste aan!
        */


    }
}
