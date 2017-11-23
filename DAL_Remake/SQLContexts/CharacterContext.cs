using DAL_Remake.Interfaces;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace DAL_Remake.SQLContexts
{
    public class CharacterContext : ICharacterContext
    {
        private SqliteConnection connection;
        private readonly string connectionString = @"Data Source=Assets/testdb.db;Version=3;";

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
            string query = "select i.ID, i.Name, i.Cost, i.Description " +
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
            string query = "select i.ID, i.Name, i.Cost, i.Description, ki.IsUsable " +
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

        public List<object[]> GetPokemon(int characterID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select * from Pokemon p" +
                                " inner join Character as c on c.id = p.characterID" +
                                " where c.id = @characterID  and p.inparty is not null";
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

        public List<object[]> GetDialogues(int characterID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select * " +
                                "from dialogue d, character c " +
                                "where d.id = c.dialogueid " +
                                "and c.ID = @CharacterID";
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
    }
}
