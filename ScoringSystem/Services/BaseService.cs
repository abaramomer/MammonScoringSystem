using ScoringSystem.Data;

namespace ScoringSystem.Services
{
    public abstract class BaseService
    {
        protected IRepository Repository;

        protected BaseService()
        {
            Repository = new FakeRepository();
        }

        protected void Commit()
        {
            Repository.SaveChanges();
            Repository.Dispose();
        }
    }
}