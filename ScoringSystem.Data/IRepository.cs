using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace ScoringSystem.Data
{
    public interface IRepository
    {
        IEnumerable<T> Get<T>() where T : BaseEntity;

        T InsertOrUpdate<T>(T entity) where T : BaseEntity;

        void Dispose();

        void SaveChanges();
    }
}