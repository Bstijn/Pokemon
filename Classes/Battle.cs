﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Classes.Exceptions;

namespace Classes
{
    public class Battle
    {
        public Player Player { get; private set; }
        public Pokemon PlayerPokemon { get; set; }
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
            return enemyPokemon.Speed > playerPokemon.Speed ? enemyPokemon : playerPokemon;
        }

        public int Attack(Pokemon attackingPokemon, Pokemon defendingPokemon, Move move)
        {
            var damageTaken = attackingPokemon.CalculateDamage(move, defendingPokemon);
            defendingPokemon.TakeDamage(damageTaken);
            return damageTaken;
        }

        public Pokemon PokemonFaintedCheck() //Return null == No Pokemon Fainted
        {
            if (WildPokemon.Fainted)
                return WildPokemon;
            if (PlayerPokemon.Fainted)
                return PlayerPokemon;
            return OpponentPokemon.Fainted ? OpponentPokemon : null;
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
            var random = new Random();
            var getalNext = random.Next(0, pokemon.GetMoves().Count());
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
            return pokemon.GetMoves().All(move => move.CurrentPP <= 0);
        }

        public Move NoPPMove()
        {
            return new Move(9999999,"Struggle", 99999,99999,100,"Does Almost nothing",false,10,0, new Type(0, "Normal"));
        }

        public void PokemonCaught(Pokemon caughtPokemon)
        {
            if (Player.Pokemons.Count < 6)
            {
                Player.Pokemons.Add(caughtPokemon);
                Player.SavePokemons(caughtPokemon.Level, caughtPokemon.PokedexId, Player.Pokemons.Count - 1);
            }
            else
            {
                Player.SavePokemons(caughtPokemon.Level, caughtPokemon.PokedexId, null);
            }
        }

        public int XpGranted(Pokemon defeatPokemon, Pokemon playerPokemon)
        {
            double formula1 = 0;
            if (WildPokemon != null)
            {
                formula1 = ((1.0 * Convert.ToDouble(defeatPokemon.DefeatXp) * Convert.ToDouble(defeatPokemon.Level)) / 5.0);
            }
            else if (OpponentPokemon != null)
            {
                formula1 = ((1.5 * Convert.ToDouble(defeatPokemon.DefeatXp) * Convert.ToDouble(defeatPokemon.Level)) / 5.0);
            }

            var formula2 = Math.Pow(2.0 * Convert.ToDouble(defeatPokemon.Level) + 10.0,2.5) / Math.Pow(defeatPokemon.Level + playerPokemon.Level + 10,2.5);

            var grantedXp = Convert.ToInt32(formula1 * formula2 + 1.0);

            return grantedXp;
        }

        public LevelUpXP GetLevelUpXp()
        {
            return PlayerPokemon.GetLevelUpXp(PlayerPokemon.Level);
        }
        public int LevelUpCheck(int xp, Pokemon playerPokemon)
        {
            var levelUpXp = playerPokemon.GetLevelUpXp(playerPokemon.Level);
            if (levelUpXp.Xp - xp >= 0) return 0;
            PlayerPokemon.LevelUp(playerPokemon);
            return xp - levelUpXp.Xp;
        }

        public void SwitchPokemon(Pokemon pokemon1, Pokemon pokemon2)//switches 2 pokemon of position in the Party.
        {
            var index1 = Player.Pokemons.IndexOf(pokemon1);
            var index2 = Player.Pokemons.IndexOf(pokemon2);
            if (index1 < index2)
            {
                Player.Pokemons.RemoveAt(index2);
                Player.Pokemons.Insert(index1, pokemon2);
                Player.Pokemons.Remove(pokemon1);
                Player.Pokemons.Insert(index2, pokemon1);
            }
            else
            {
                Player.Pokemons.RemoveAt(index1);
                Player.Pokemons.Insert(index2, pokemon1);
                Player.Pokemons.Remove(pokemon2);
                Player.Pokemons.Insert(index1, pokemon2);
            }
        }

        public List<Possesion> GetSpecificItem(System.Type type)
        {
            List<Possesion> specificItemsList = new List<Possesion>();
            foreach(Possesion pos in Player.Inventory)
            {
                if(pos.Item.GetType() == type)
                {
                    specificItemsList.Add(pos);
                }
                
            }
            return specificItemsList;
        }

        public void UpdatePokemon()
        {
            Player.UpdatePokemons();
        }
    }
}
