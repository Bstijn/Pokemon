using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;

namespace Classes.Repos
{
    public class PokedexRepository
    {
        private IPokedexContext context;

        public PokedexRepository()
        {
            context = new PokedexContext();
        }

        public List<Pokemon> GetSeenPokemon()
        {
            List<object[]> data = context.GetSeenPokemon();
            List<Pokemon> pokemon = new List<Pokemon>();

            foreach (object[] row in data)
            {
                object[] typeData = context.GetPokemonType(Convert.ToInt32(row[0]));
                Type type = new Type(Convert.ToInt32(typeData[0]), typeData[1].ToString());
                List<Move> pokemonMoves = GetPokemonMoves(Convert.ToInt32(row[0]));

                pokemon.Add(new Pokemon(type, pokemonMoves, Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToBoolean(row[2]),
                    Convert.ToInt32(row[3]), Convert.ToInt32(row[4]), Convert.ToInt32(row[5]), Convert.ToInt32(row[6]),
                    Convert.ToInt32(row[7]), Convert.ToInt32(row[8]), Convert.ToInt32(row[9]), Convert.ToInt32(row[10]),
                    Convert.ToInt32(row[11])));
            }
            return pokemon;
        }

        public List<Pokemon> GetOwnedPokemon()
        {
            List<object[]> data = context.GetSeenPokemon();
            List<Pokemon> pokemon = new List<Pokemon>();

            foreach (object[] row in data)
            {
                object[] typeData = context.GetPokemonType(Convert.ToInt32(row[0]));
                Type type = new Type(Convert.ToInt32(typeData[0]), typeData[1].ToString());
                List<Move> pokemonMoves = GetPokemonMoves(Convert.ToInt32(row[0]));

                pokemon.Add(new Pokemon(type, pokemonMoves, Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToBoolean(row[2]),
                    Convert.ToInt32(row[3]), Convert.ToInt32(row[4]), Convert.ToInt32(row[5]), Convert.ToInt32(row[6]),
                    Convert.ToInt32(row[7]), Convert.ToInt32(row[8]), Convert.ToInt32(row[9]), Convert.ToInt32(row[10]),
                    Convert.ToInt32(row[11])));
            }
            return pokemon;
        }

        public Type GetPokemonType(int pokemonID)
        {
            object[] data = context.GetPokemonType(pokemonID);

            return new Type(Convert.ToInt32(data[0]), data[1].ToString());
        }

        public List<Move> GetPokemonMoves(int pokemonID)
        {
            List<object[]> data = context.GetPokemonMoves(pokemonID);
            List<Move> pokemonMoves = new List<Move>();

            foreach (object[] row in data)
            {
                pokemonMoves.Add(new Move(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]),
                    Convert.ToInt32(row[4]), row[5].ToString(), Convert.ToBoolean(row[6]), Convert.ToInt32(row[7]), Convert.ToInt32(row[8]), GetMoveType(Convert.ToInt32(row[0]))));
            }

            return pokemonMoves;
        }

        public Type GetMoveType(int moveID)
        {
            object[] data = context.GetMoveType(moveID);

            return new Type(Convert.ToInt32(data[0]), data[1].ToString());
        }
    }
}
