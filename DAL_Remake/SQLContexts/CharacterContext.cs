using DAL_Remake.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Remake.SQLContexts
{
    public class CharacterContext : ICharacterContext
    {
        private SQLiteConnection connection;
        private readonly string connectionString = @"Data Source=Assets/testdb.db;Version=3;";

        public List<object[]> GetItems(int characterID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select * from Possesion p" +
                                " where p.characterID = @characterID";

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
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

        public List<object[]> GetPokemon(int characterID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select * from Character c" +
                                " inner join Pokemon as p on p.characterId = c.id" +
                                " where c.id = @characterID  and p.inparty is not null";
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
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
            string query = "select * from Choice c" +
                                " inner join Dialogue d" +
                                " on c.FromDialogueID = d.ID" +
                                " inner join character ch" +
                                " on ch.dialogue = d.ID" +
                                " where ch.ID = @CharacterID";
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
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
