using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ScoringSystem.Data.Entities;

namespace ScoringSystem.Data.EntityProviders
{
    public abstract class EntityProviderBase<T> : IEntityProvider where T : BaseEntity
    {
        public Type EntityType 
        { 
            get { return typeof(T); }
        }

        public abstract List<string> Columns { get; }

        public abstract string TableName { get; }

        public BaseEntity MapFromReader(MySqlDataReader dataReader)
        {
            return EntityFromReader(dataReader);
        }

        public Dictionary<string, object> MapToColumnValues(BaseEntity entity)
        {
            return GetColumnValues((T) entity);
        }

        protected abstract Dictionary<string, object> GetColumnValues(T entity);
 

        protected A GetFromReader<A>(string column, MySqlDataReader dataReader)
        {
            return (A) dataReader[column];
        }

        protected abstract T EntityFromReader(MySqlDataReader dataReader);
    }
}