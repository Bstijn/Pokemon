using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
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
            if (enemyPokemon.Speed > playerPokemon.Speed)
            {
                return enemyPokemon;
            }
            return playerPokemon;
        }

        public int Attack(Pokemon attackingPokemon, Pokemon defendingPokemon, Move move)
        {
            int damageTaken = attackingPokemon.CalculateDamage(move, defendingPokemon);
            defendingPokemon.TakeDamage(damageTaken);
            return damageTaken;
        }

        public Pokemon PokemonFaintedCheck() //Return null == No Pokemon Fainted
        {
            if (WildPokemon.Fainted)
                return WildPokemon;
            if (PlayerPokemon.Fainted)
                return PlayerPokemon;
            if (OpponentPokemon.Fainted)
                return OpponentPokemon;
            return null;

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

        public Move PickRandomMove(Pokemon pokemon)
        {
            if (NoPPCheck(pokemon))
            {
                return NoPPMove();
            }
            NoPPOnMove:
            Random random = new Random();
            int getalNext = random.Next(0, pokemon.GetMoves().Count());
            if (pokemon.GetMoves()[getalNext].CurrentPP > 0)
            {
                return pokemon.GetMoves()[getalNext];
            }
            goto NoPPOnMove;
        }

        /// <summary>
        /// This Function checks the PP on moves
        /// </summary>
        /// <param name="pokemon">Pokemon to check</param>
        /// <returns>true on no pp</returns>
        public bool NoPPCheck(Pokemon pokemon) 
        {
            foreach (Move move in pokemon.GetMoves())
            {
                if (move.CurrentPP > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public Move NoPPMove()
        {
            return new Move(9999999,"Struggle", 99999,99999,100,"Did close to nothing",false,10,0);
        }

        public void PokemonCaught(Pokemon caughtPokemon)
        {
            if (Player.Pokemons.Count() < 6)
            {
                Player.Pokemons.Add(caughtPokemon);
            }
            else
            {
                //TODO Database Pokemon Caught --> Party caught
            }
        }

    }
}
