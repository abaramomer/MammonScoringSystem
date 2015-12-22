using ScoringSystem.Data;

namespace ScoringSystem.Services
{
    public abstract class BaseService
    {
        protected ApplicationRepository Repository;

        protected BaseService()
        {
            Repository = new ApplicationRepository();
        }

        protected void Commit()
        {
            Repository.SaveChanges();
            Repository.Dispose();
        }
    }
}