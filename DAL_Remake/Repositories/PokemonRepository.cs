
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;

namespace DAL_Remake.Repositories
{
    public class PokemonRepository
    {
        private IPokemonContext context;

        public PokemonRepository(IPokemonContext context)
        {
            context = new PokemonContext();
        }

        public List<Move> GetMoves(int pokemonID)
        {
            List<Move> moves = new List<Move>();
            List<object[]> moveData = context.GetMoves(pokemonID);
            //foreach (object[] move in moveData)
            //{
            //    moves.Add(new Move(move[0], move[1], move[2], ))
            //}
            return moves;
        }

        public object[] GetPokemonType()
        {
            return context.GetPokemonType();
        }

    }
}
