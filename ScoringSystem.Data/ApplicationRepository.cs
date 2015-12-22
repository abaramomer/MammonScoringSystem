using System.Data.Entity;

namespace ScoringSystem.Data
{
    public class ApplicationRepository
    {
        private ApplicationContext applicationContext;

        public IDbSet<T> Get<T>() where T : BaseEntity
        {
            applicationContext = new ApplicationContext();

            return applicationContext.Set<T>();
        }

        public void SaveAndDispose()
        {
            applicationContext.SaveChanges();
            applicationContext.Dispose();
        }
    }
}