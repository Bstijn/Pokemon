using DAL_Remake.Interfaces;
using Mono.Data.Sqlite;
using System.Collections.Generic;

namespace DAL_Remake.SQLContexts
{
    public class PokedexContext : IPokedexContext
    {
        private SqliteConnection connection;
        private readonly string connectionString = @"Data Source=Assets/testdb.db;Version=3;";

        public PokedexContext()
        {
            connection = new SqliteConnection(connectionString);
        }

        public List<object[]> GetSeenPokemon()
        {
            return new List<object[]>();
        }

        public List<object[]> GetOwnedPokemon()
        {
            return new List<object[]>();
        }
    }
}
