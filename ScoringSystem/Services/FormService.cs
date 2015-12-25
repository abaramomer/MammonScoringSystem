using System.Collections.Generic;
using System.Linq;
using ScoringSystem.Data;
using ScoringSystem.Data.Entities;
using ScoringSystem.ModelBuilders;
using ScoringSystem.Models;

namespace ScoringSystem.Services
{
    public class FormService : BaseService
    {
        public List<QuestionModel> GetFormQuestions()
        {
            var questions = Repository.Get<Question>(null).ToList();

            var answers = Repository.Get<Answer>(null).ToList();
            
            return QuestionModelMapper.MapToQuestionModels(questions, answers);
        } 
    }
}