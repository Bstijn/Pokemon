using DAL_Remake.Interfaces;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;

namespace DAL_Remake.SQLContexts
{
    public class PokedexContext : IPokedexContext
    {
        private SqliteConnection connection;
        private readonly string connectionString = @"Data Source=Assets/DBProftaak.db;Version=3;";

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
            string query = "select p.id, pp.name, p.inParty, p.level, p.currentHp, p.maxHp, p.xp, p.attack, p.defense, p.speed, pp.evolveLevel, pp.captureRate " +
                                    "from pokemon p, pokedexpokemon pp " +
                                    "where p.pokedexpokemonID = pp.ID " +
                                    "and p.ID = @PokemonID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@PokemonID", pokemonID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                data = dataTable.Rows[0].ItemArray;
            }
            return data;
        }

        public object[] GetPokemonType(int pokemonID)
        {
            object[] data;
            string query = "select t.ID, t.Name " +
                                    "from type t, pokedexpokemon pp, pokemon p " +
                                    "where t.id = pp.typeID " +
                                    "and pp.ID = p.pokedexpokemonID " +
                                    "and p.ID = @PokemonID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@PokemonID", pokemonID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                data = dataTable.Rows[0].ItemArray;
            }
            return data;
        }

        public List<object[]> GetPokemonMoves(int pokemonID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select m.ID, pdm.name, m.currentPP, pdm.maxPP, pdm.accuracy, pdm.description, pdm.hasOverworldEffect, pdm.basePower, pm.minlevel " +
                                    "from move m, pokemonMoves pm, pokedexMove pdm " +
                                    "where m.pmid = pm.ID " +
                                    "and pm.ID = pdm.ID " +
                                    "and m.pokemonID = @PokemonID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@PokemonID", pokemonID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }

        public object[] GetMoveType(int moveID)
        {
            object[] data;
            string query = "select t.ID, t.Name " +
                           "from type t, pokedexmove pm" +
                           "where t.id = pm.typeID " +
                           "and pm.ID = @MoveID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@MoveID", moveID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                data = dataTable.Rows[0].ItemArray;
            }
            return data;
        }
    }
}
