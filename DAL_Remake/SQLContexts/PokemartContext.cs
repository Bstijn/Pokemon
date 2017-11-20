using System.Data.SQLite;
using DAL_Remake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL_Remake.SQLContexts
{
    public class PokemartContext : IPokemartContext
    {
        private SQLiteConnection connection;
        private readonly string connectionString = @"Data Source=Assets/testdb.db;Version=3;";

        public PokemartContext()
        {
            connection = new SQLiteConnection(connectionString);
        }

        public List<object[]> GetConsumables(string pokemartName)
        {
            List<object[]> data = new List<object[]>();
            string query = "select I.Name, I.Cost, I.Description from PokeMart pm" +
                             " inner join ConsumablePokeMart as cp on PokeMartId = BuildingId" +
                             " inner join Building as b on pm.BuildingID = b.ID" +
                             " inner join Location as L on b.Id = L.id" +
                             " inner join Consumable as c on cp.ConsumableID = c.Id" +
                             " inner join Item as I on c.Id = I.ID" +
                             " where L.Name = @pokemartName";
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@pokemartName", pokemartName);
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
