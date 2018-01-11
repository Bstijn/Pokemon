using DAL_Remake.Interfaces;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


namespace DAL_Remake.SQLContexts
{
    public class PlayerContext : IPlayerContext
    {
        private SqliteConnection connection;

        private readonly string connectionString = @"Data Source =" + @Application.dataPath + @"\DBProftaak.db;Version=3; ";

        public PlayerContext()
        {
            connection = new SqliteConnection(connectionString);
        }

        public void Save()
        {

        }

        public object[] Load()
        {
            object[] data = null;
            string query =
                "select c.Name, c.ID, c.Gender, c.Money, cl.PosX, cl.PosY, p.Wins, p.Losses, cl.LocationID " +
                "from Character c, Player p, CharacterLocation cl " +
                "where c.ID = p.CharacterID " +
                "and c.ID = cl.CharacterID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                data = dataTable.Rows[0].ItemArray;
            }
            return data;
        }

        public List<object[]> GetRevives(int characterID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select i.ID, i.Name, i.Cost, i.Description, r.Percentage " +
                           "from Posession p, Item i, Consumable c, Revive r " +
                           "where p.CharacterID = @CharacterID " +
                           "and p.ItemID = i.ID " +
                           "and i.ID = c.ItemID " +
                           "and c.ItemID = r.ConsumableID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@CharacterID", characterID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }

        public List<object[]> GetPotions(int characterID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select i.ID, i.Name, i.Cost, i.Description, h.HealAmount " +
                           "from Posession p, Item i, Consumable c, HealthPotion h " +
                           "where p.CharacterID = @CharacterID " +
                           "and p.ItemID = i.ID " +
                           "and i.ID = c.ItemID " +
                           "and c.ItemID = h.ConsumableID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@CharacterID", characterID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }

        public List<object[]> GetPokeballs(int characterID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select i.ID, i.Name, i.Cost, i.Description, pb.CatchRate " +
                           "from Posession p, Item i, Consumable c, Pokeball pb " +
                           "where p.CharacterID = @CharacterID " +
                           "and p.ItemID = i.ID " +
                           "and i.ID = c.ItemID " +
                           "and c.ItemID = pb.ConsumableID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@CharacterID", characterID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }

        public List<object[]> GetBadges(int characterID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select i.ID, i.Name, i.Description " +
                           "from Posession p, Item i, NonConsumable nc, Badge b " +
                           "where p.CharacterID = @CharacterID " +
                           "and p.ItemID = i.ID " +
                           "and i.ID = nc.ItemID " +
                           "and nc.ItemID = b.NCID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@CharacterID", characterID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }

        public List<object[]> GetKeyItems(int characterID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select i.ID, i.Name, i.Description, ki.IsUsable " +
                           "from Posession p, Item i, NonConsumable nc, KeyItem ki " +
                           "where p.CharacterID = @CharacterID " +
                           "and p.ItemID = i.ID " +
                           "and i.ID = nc.ItemID " +
                           "and nc.ItemID = ki.NCID";

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

        public List<object[]> GetPokemonFromParty(int characterID)
        {
            List<object[]> data = new List<object[]>();
            string query =
                "select p.id, pp.name, p.inParty, p.level, p.currentHp, p.maxHp, p.xp, p.attack, p.defense, p.speed, pp.evolveLevel, pp.captureRate " +
                "from pokemon p, pokedexpokemon pp " +
                "where p.pokedexpokemonID = pp.ID " +
                "and p.InParty = 1 " +
                "and p.CharacterID = @CharacterID";
            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@characterID", characterID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }


        public List<object[]> GetPokemonMoves(int pokemonID)
        {
            List<object[]> data = new List<object[]>();
            string query =
                "select m.ID, pdm.name, m.currentPP, pdm.maxPP, pdm.accuracy, pdm.description, pdm.hasOverworldEffect, pdm.basePower, pm.minlevel " +
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
    }
}
