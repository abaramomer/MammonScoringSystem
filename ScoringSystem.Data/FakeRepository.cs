using System.Collections.Generic;
using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace ScoringSystem.Data
{
    public class FakeRepository : IRepository
    {
        public IEnumerable<T> Get<T>() where T : BaseEntity
        {
            if (typeof (T) == typeof (Question))
            {
                return new QuestionInitializer().GetInitialQuestions() as IEnumerable<T>;
            }

            MySqlConnection connection = new MySqlConnection("server=localhost;user id=mammonuser;database=mytable;password=s");
            connection.Open();
            MySqlCommand command = new MySqlCommand(@"CREATE TABLE mytable.sss (
              Id INT NOT NULL AUTO_INCREMENT,
              MyS VARCHAR(45) NULL,
              PRIMARY KEY (Id))", connection);

            command.ExecuteNonQuery();

            connection.Close();

            return null;
        }

        public T InsertOrUpdate<T>(T entity) where T : BaseEntity
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {  
        }

        public void SaveChanges()
        {
        }
    }
}