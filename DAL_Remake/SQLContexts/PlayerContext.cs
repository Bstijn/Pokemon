using DAL_Remake.Interfaces;
using Mono.Data.Sqlite;
using System.Data;

namespace DAL_Remake.SQLContexts
{
    public class PlayerContext : IPlayerContext
    {
        private SqliteConnection connection;
        private readonly string connectionString = @"Data Source=Assets/DBProftaak.db;Version=3;";

        public PlayerContext()
        {
            connection = new SqliteConnection(connectionString);
        }

        public void Save()
        {

        }

        public void Load()
        {

        }
    }
}
