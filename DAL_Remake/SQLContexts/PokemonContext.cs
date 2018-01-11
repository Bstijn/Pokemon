using System;
using DAL_Remake.Interfaces;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using UnityEngine;

namespace DAL_Remake.SQLContexts
{
    public class PokemonContext : IPokemonContext
    {
        private SqliteConnection connection;
        private readonly string connectionString = @"Data Source =" + @Application.dataPath + @"\DBProftaak.db;Version=3; ";

        public PokemonContext()
        {
            connection = new SqliteConnection(connectionString);
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

        public object GetEffectiveness(int attackTypeID, int defenseTypeID)
        {
            object data;
            string query = "SELECT DamageRatio FROM Effectiveness WHERE AttackTypeID = 1 AND DefenseTypeID = 2;";

            DataTable dataTable = new DataTable();
            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@AttackTypeID", attackTypeID);
                adapter.SelectCommand.Parameters.AddWithValue("@DefenseTypeID", defenseTypeID);
                adapter.Fill(dataTable);
                data = dataTable.Rows[0].ItemArray[0];
            }

            return data;
        }

        /*public LevelUpXP GetLvlUp(int level)
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
