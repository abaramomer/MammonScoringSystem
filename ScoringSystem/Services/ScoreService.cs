using System.Collections.Generic;
using System.Linq;
using ScoringSystem.Data;
using ScoringSystem.Models;

namespace ScoringSystem.Services
{
    public class ScoreService : BaseService
    {
        public int CalculateScores(List<UserAnswer> answers)
        {
            return Repository.Get<Form>().Count();
        }
    }
}