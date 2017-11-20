using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL_Remake.SQLContexts
{
    public class PokemonContext :IPokemonContext
    {
        private SQLiteConnection connection;
        private readonly string connectionString = @"Data Source=Assets/testdb.db;Version=3;";

        public List<object[]> GetMoves(int pokemonID)
        {
            List<object[]> data = new List<object[]>();
            string query = "select m.id,m.currentpp,pdm.Name,pdm.Description,pdm.maxpp,pdm.accuracy,pdm.hasoverworldeffect,pdm.basepower,t.name from Move as m" +
                                " inner join PokemonMove as pm on pm.ID = m.PMID" +
                                " inner join PokedexMove as pdm on pm.id = pdm.id" +
                                " inner join Type as t on Pdm.TypeID = t.id" +
                                " where m.PokemonID = @pokemonID";

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
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

        public object[] GetPokemonType()
        {
            return null;
        }
    }
}
