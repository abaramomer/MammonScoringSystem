using System;
using System.Collections.Generic;
using System.Configuration;
using ScoringSystem.Data.Entities;
using ScoringSystem.Data.EntityProviders;

namespace ScoringSystem.Data
{
    public class Repository : IRepository
    {
        private List<IEntityProvider> providers;
        private MySqlProvider mySqlProvider;
        private QueryBuilder queryBuilder;

        public Repository()
        {
            queryBuilder = new QueryBuilder();
            mySqlProvider = new MySqlProvider(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            providers = new List<IEntityProvider>
            {
                new QuestionProvider(),
                new AnswerProvider()
            };
        }

        public IList<T> Get<T>(Condition condition) where T : BaseEntity
        {
            var provider = GetProvider(typeof (T));

            var query = queryBuilder.SelectQuery(provider, condition);

            var reader = mySqlProvider.ExecuteWithReader(query);
            List<T> entities = new List<T>();

            while (reader.Read())
            {
                entities.Add((T) provider.MapFromReader(reader));
            }

            reader.Close();

            return entities;
        }

        public T InsertOrUpdate<T>(T entity) where T : BaseEntity
        {
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            mySqlProvider.Connection.Close();
        } 

        private IEntityProvider GetProvider(Type entityType)
        {
            return providers.Find(p => p.EntityType == entityType);
        }
    }
}