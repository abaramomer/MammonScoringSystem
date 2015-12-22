using System;
using System.Collections.Generic;
using System.Linq;
using ScoringSystem.Data;
using ScoringSystem.Models;

namespace ScoringSystem.Services
{
    public class FormService : BaseService
    {
        public List<QuestionModel> GetAvailableQuestions()
        {
            var questions = Repository.Get<Question>().ToList();
            Repository.Dispose();

            List<QuestionModel> questionModels = new List<QuestionModel>();

            return questionModels;
        }
    }
}