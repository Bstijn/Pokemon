using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DataAccessLayer
{
    public class DbConnection
    {
        private static readonly string connectionString = "Data Source=DBProftaak.db;Version=3";
        private static SQLiteConnection connection;
        private static SQLiteCommand command;
        public static void OpenConnection()
        {
            connection = new SQLiteConnection(connectionString);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public static int Create(string query)
        {
            try
            {
                OpenConnection();
                command = new SQLiteCommand(query, connection);

                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }
        }

        public static bool Update(string query)
        {
            try
            {
                OpenConnection();
                command = new SQLiteCommand(query, connection);

                if (command.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public static bool Delete(string query)
        {
            try
            {
                OpenConnection();
                command = new SQLiteCommand(query, connection);

                return (bool)command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public static List<object[]> Read(string query)
        {
            try
            {
                OpenConnection();
                List<object[]> data = new List<object[]>();
                command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object[] line = new object[reader.FieldCount];
                    reader.GetValues(line);
                    data.Add(line);
                }
                return data;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
    }
}