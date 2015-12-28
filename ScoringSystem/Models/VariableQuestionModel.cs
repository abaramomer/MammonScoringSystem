using System.Collections.Generic;
using ScoringSystem.Data.Entities;

namespace ScoringSystem.Models
{
    public class VariableQuestionModel : QuestionModel
    {
        public List<AnswerModel> Answers { get; set; } 
    }
}