using System.Collections.Generic;
using ScoringSystem.Data.Entities;

namespace ScoringSystem.Data
{
    public interface IRepository
    {
        IList<T> Get<T>(Condition condition) where T : BaseEntity;

        T Get<T>(int id) where T : BaseEntity;

        T InsertOrUpdate<T>(T entity) where T : BaseEntity;

        void Close();
    }
}