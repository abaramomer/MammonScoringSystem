using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
                new AnswerProvider(),
                new FormAnswerProvider(),
                new FormProvider()
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

        public T Get<T>(int id) where T : BaseEntity
        {
            return Get<T>(Condition.IdentityCondition(id)).Single();
        }

        public T InsertOrUpdate<T>(T entity) where T : BaseEntity
        {
            bool isNew = !Get<T>(Condition.IdentityCondition(entity.Id)).Any();

            var provider = GetProvider(typeof (T));

            if(isNew)
            {
                var insertedId = Insert(provider, provider.MapToColumnValues(entity));

                entity.Id = insertedId;

                return entity;
            }

            Update(provider, entity.Id, provider.MapToColumnValues(entity));

            return entity;
        }

        public void Close()
        {
            mySqlProvider.Connection.Close();
        }

        private int Insert(IEntityProvider provider, Dictionary<string, object> values)
        {
            var insertQuery = queryBuilder.InsertQuery(provider, values);

            return mySqlProvider.ExecuteScalar(insertQuery);
        }

        private void Update(IEntityProvider provider, int id, Dictionary<string, object> values)
        {
            var updateQuery = queryBuilder.UpdateQuery(provider, Condition.IdentityCondition(id), values);

            mySqlProvider.ExecuteNonQuery(updateQuery);
        }

        private IEntityProvider GetProvider(Type entityType)
        {
            return providers.Find(p => p.EntityType == entityType);
        }
    }
}