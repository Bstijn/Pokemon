using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using DAL_Remake.Interfaces;

namespace DAL_Remake.SQLContexts
{
    public class LocationContext : ILocationContext
    {
        private SqliteConnection connection;
        private readonly string connectionString = @"Data Source=Assets/testdb.db;Version=3;";

        public LocationContext()
        {
            connection = new SqliteConnection(connectionString);
        }

        public object[] GetGymleader(int locationID)
        {
            object[] data;
            string query = "";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@locationID", locationID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                data = dataTable.Rows[0].ItemArray;
            }
            return data;
        }

        public object[] GetNurse(int locationID)
        {
            object[] data;
            string query = "";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@locationID", locationID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                data = dataTable.Rows[0].ItemArray;
            }
            return data;
        }

        public object[] GetShopkeeper(int locationID)
        {
            object[] data;
            string query = "";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@locationID", locationID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                data = dataTable.Rows[0].ItemArray;
            }
            return data;
        }

        public List<object[]> GetOpponents(int locationID)
        {
            List<object[]> data = new List<object[]>();
            string query = "";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@locationID", locationID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }

        public List<object[]> GetBystanders(int locationID)
        {
            List<object[]> data = new List<object[]>();
            string query = "";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@locationID", locationID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }


        public List<object[]> GetPassages(int locationID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select id, fromx, fromy, tox, toy, tolocationid " +
                                    "from passage " +
                                    "where fromlocationid = @locationID";

            using (SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@locationID", locationID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    data.Add(dataRow.ItemArray);
                }
            }
            return data;
        }

        public List<object[]> GetPokemon(int locationID)
        {
            return new List<object[]>();
        }
    }
}
