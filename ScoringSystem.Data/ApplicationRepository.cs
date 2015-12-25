using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ScoringSystem.Data
{
    public class ApplicationRepository : IDisposable, IRepository
    {
        private ApplicationContext applicationContext;

        public IEnumerable<T> Get<T>() where T : BaseEntity
        {
            if (applicationContext == null)
            {
                applicationContext = new ApplicationContext();
            }

            return applicationContext.Set<T>();
        }

        public virtual T InsertOrUpdate<T>(T entity) where T : BaseEntity
        {
            if (applicationContext == null)
            {
                applicationContext = new ApplicationContext();
            }

            applicationContext.Set<T>().Add(entity);

            return entity;
        }

        public void SaveChanges()
        {
            applicationContext.SaveChanges();
        }

        public void Dispose()
        {
            applicationContext.Dispose();
        }
    }
}