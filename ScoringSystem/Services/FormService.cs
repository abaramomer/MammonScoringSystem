using System.Collections.Generic;
using System.Linq;
using ScoringSystem.Data;
using ScoringSystem.Models;

namespace ScoringSystem.Services
{
    public class FormService : BaseService
    {
        public List<Question> GetFormQuestions()
        {
            var questions = Repository.Get<Question>().ToList();

            Repository.Dispose();

            return questions;
        }
    }
}