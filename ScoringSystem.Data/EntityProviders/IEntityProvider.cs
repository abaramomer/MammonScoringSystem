using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ScoringSystem.Data.Entities;

namespace ScoringSystem.Data.EntityProviders
{
    public interface IEntityProvider
    {
        List<string> Columns { get; }

        string TableName { get; }

        Type EntityType { get; }

        BaseEntity MapFromReader(MySqlDataReader dataReader);

        Dictionary<string, object> MapToColumnValues(BaseEntity entity);
    }
}