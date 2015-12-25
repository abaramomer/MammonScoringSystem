using System.Collections.Generic;
using System.Linq;
using ScoringSystem.Data.Entities;
using ScoringSystem.Models;

namespace ScoringSystem.ModelBuilders
{
    public static class QuestionModelMapper
    {
        public static List<QuestionModel> MapToQuestionModels(List<Question> questions, List<Answer> answers)
        {
            var questionModels = new List<QuestionModel>();

            foreach (var question in questions)
            {
                QuestionModel questionModel;
                if(question.QuestionType == QuestionType.Bool)
                {
                    questionModel = new BoolQuestionModel();
                }
                else
                {
                    questionModel = new VariableQuestionModel
                    {
                        Answers = answers.Where(a => a.QuestionId == question.Id).ToList()
                    };
                }

                questionModel.Id = question.Id;
                questionModel.Text = question.Text;

                questionModels.Add(questionModel);
            }

            return questionModels;
        }
    }
}