using System.Configuration;

using Npgsql;

namespace ScoringSystem.Data.ExternalData
{
    public class MammonBankRepository
    {
        private readonly NpgsqlConnection connection;

        private const string SelectClientUniqueLinkQuery = "SELECT id FROM clients WHERE scoring_form_id='{0}'";

        public MammonBankRepository()
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["MammonBank"].ConnectionString);
        }

        public int ClientIdByLink(string link)
        {
            connection.Open();
            var query = string.Format(SelectClientUniqueLinkQuery, link);
            var command = new NpgsqlCommand(query, connection);

            var reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                reader.Read();

                var id = reader["id"];

                reader.Close();
                connection.Close();

                return (int)id;
            }

            return -1;
        }

    }
}