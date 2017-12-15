using System.Data;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using DAL_Remake.Interfaces;
using Mono.Data.Sqlite;
using Classes;

namespace DAL_Remake.SQLContexts
{
    public class PokemonContext : IPokemonContext
    {
        private SqliteConnection connection;
        private readonly string connectionString = @"Data Source=Assets/testdb.db;Version=3;";

        public PokemonContext()
        {
            connection = new SqliteConnection(connectionString);
        }

        public Pokemon GetEvolvePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public List<object[]> GetMoves(int pokemonID)
        {
            List<object[]> data = new List<object[]>();
            string query =
                "select m.id, pdm.Name, m.currentpp, pdm.maxpp, pdm.accuracy, pdm.Description, pdm.hasoverworldeffect, pdm.basepower, pm.minlevel " +
                "from Move as m " +
                "inner join PokemonMove as pm " +
                "on pm.ID = m.PMID " +
                "inner join PokedexMove as pdm on pm.id = pdm.id " +
                "inner join Type as t on Pdm.TypeID = t.id " +
                "where m.PokemonID = @pokemonID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@pokemonID", pokemonID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }

        public object[] GetNextLevelUpXp(int level)
        {
            throw new NotImplementedException();
        }

        public object[] GetPokemonType(int pokedexPokemonID)
        {
            object[] data;
            string query = "select t.* " +
                           "from Type t, PokedexPokemon pp " +
                           "where t.ID = pp.TypeID " +
                           "and pp.ID = @PokedexPokemonID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@PokedexPokemonID", pokedexPokemonID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                data = dataTable.Rows[0].ItemArray;
            }
            return data;

        }

        public void UpdatePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        /*
        public LevelUpXP GetNextLevelUpXp(int level)

        public object[] GetNextLevelUpXp(int level)
        {
            object[] levelUpXp;
            string query = "Select * from LevelUpXP " +
                           "where lvl = ";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@PokemonLvl", level + 1);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                levelUpXp = dataTable.Rows[0].ItemArray;
                return levelUpXp;

            }
        }

        public void UpdatePokemon(Pokemon pokemon)//TODO Query update pokemon
        {
            throw new NotImplementedException();
        }

        public Pokemon GetEvolvePokemon(Pokemon pokemon)//TODO Get Evolve Pokemon Database
        {

            throw new NotImplementedException()
        }*/
    }
}
