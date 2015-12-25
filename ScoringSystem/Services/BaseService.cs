using ScoringSystem.Data;

namespace ScoringSystem.Services
{
    public abstract class BaseService
    {
        protected IRepository Repository;

        protected BaseService()
        {
            Repository = new Repository();
        }

        protected void Commit()
        {
            Repository.Commit();
        }
    }
}