using System;
using System.Configuration;
using System.Data;
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
            try
            {

                var query = string.Format(SelectClientUniqueLinkQuery, link);
                var command = new NpgsqlCommand(query, connection);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    var id = reader["id"];

                    reader.Close();
                    connection.Close();

                    return (int) id;
                }

                connection.Close();
            }

            finally
            {
                if(connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return -1;
        }

    }
}