using DAL_Remake.Interfaces;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;

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
            List<object[]> data = new List<object[]>();
            string query = "select ID " +
                                "from PokedexPokemon " +
                                "where seen = 1";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }

        public List<object[]> GetOwnedPokemon()
        {
            List<object[]> data = new List<object[]>();
            string query = "select ID " +
                                "from PokedexPokemon " +
                                "where owned = 1";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }

        public object[] GetPokemonByID(int pokemonID)
        {
            object[] data;
            string query = "";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                data = dataTable.Rows[0].ItemArray;
            }
            return data;
        }
    }
}
