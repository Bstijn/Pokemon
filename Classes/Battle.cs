using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Classes.Exceptions;

namespace Classes
{
    public class Battle
    {

        public Player Player { get; private set; }
        public Pokemon PlayerPokemon { get; private set; }
        public Pokemon WildPokemon { get; private set; }
        public Oppenent Opponent { get; private set; }
        public Pokemon OpponentPokemon { get; private set; }
        public int FleeAttempts { get; private set; }

        //TODO Implementeer EXP
        //TODO Pokemon lvlup Check
        //TODO Item gebruiken

        public Battle(Player player,Pokemon wildPokemon)
        {
            this.Player = player;
            this.WildPokemon = wildPokemon;
            this.PlayerPokemon = player.Pokemons[0];
        }

        public Battle(Player player, Oppenent opponent)
        {
            this.Player = player;
            this.Opponent = opponent;
            this.PlayerPokemon = player.Pokemons[0];
            this.OpponentPokemon = opponent.Pokemons[0];
        }

        public Pokemon FirstAttack(Pokemon enemyPokemon, Pokemon playerPokemon)
        {
            //TODO FirstAttack MUST
            throw new NotImplementedException();
        }

        public int Attack(Pokemon attackingPokemon, Pokemon defendingPokemon, Move move)
        {
            //var selectedDefendingPokemon = Pokemons.First(p => targetPokemon.Id == p.Id);

            //TODO Attack MUST
            throw new NotImplementedException();
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
    }
}
