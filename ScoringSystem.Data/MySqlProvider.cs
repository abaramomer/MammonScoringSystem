using System.Data;
using MySql.Data.MySqlClient;

namespace ScoringSystem.Data
{
    public class MySqlProvider
    {
        public MySqlProvider(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection Connection { get; private set; }


        public MySqlDataReader ExecuteWithReader(string query)
        {
            var command = PrepareCommand(query);

            return command.ExecuteReader();
        }

        public int ExecuteScalar(string query)
        {
            var command = PrepareCommand(query);

            command.ExecuteNonQuery();

            return (int)command.LastInsertedId;
        }

        public void ExecuteNonQuery(string query)
        {
            var command = PrepareCommand(query);

            command.ExecuteNonQuery();
        }

        private MySqlCommand PrepareCommand(string query)
        {
            if(Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            return new MySqlCommand(query, Connection);
        }
    }
}