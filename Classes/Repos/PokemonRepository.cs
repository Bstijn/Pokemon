using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;

namespace Classes.Repos
{
    public class PokemonRepository
    {
        private IPokemonContext context;

        public PokemonRepository()
        {
            context = new PokemonContext();
        }

        public List<Move> GetMoves(int pokemonID)
        {
            List<Move> moves = new List<Move>();
            List<object[]> data = context.GetMoves(pokemonID);

            foreach (object[] row in data)
            {
                moves.Add(new Move(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]),
                    Convert.ToInt32(row[4]), row[5].ToString(), Convert.ToBoolean(row[6]), Convert.ToInt32(row[7]), Convert.ToInt32(row[8]), GetMoveType(Convert.ToInt32(row[0]))));
            }

            return moves;
        }

        public Type GetPokemonType(int pokedexPokemonID)
        {
            object[] data = context.GetPokemonType(pokedexPokemonID);
            return new Type(Convert.ToInt32(data[0]), data[1].ToString());
        }

        public Type GetMoveType(int moveID)
        {
            object[] data = context.GetMoveType(moveID);
            return new Type(Convert.ToInt32(data[0]), data[1].ToString());
        }

        public double GetEffectiveness(Type attackType, Type defenceType)
        {
            object data = context.GetEffectiveness(attackType.Id, defenceType.Id);
            return Convert.ToDouble(data);
        }
        
        public LevelUpXP GetNextLevelUpXp(int level)
        {
            object[] data = context.GetNextLevelUpXp(level);
            LevelUpXP levelUpXp = new LevelUpXP(Convert.ToInt32(data[0]),Convert.ToInt32(data[1]));
            return levelUpXp;
        }

        public void UpdatePokemon(Pokemon pokemon)//TODO Query voor updaten van pokemon
        {
            context.UpdatePokemon(pokemon);
        }

        public Pokemon GetEvolvePokemon(Pokemon pokemon)
        {
            return context.GetEvolvePokemon(pokemon);
        }
    }
}
