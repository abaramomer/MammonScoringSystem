using System.Collections.Generic;
using System.Linq;
using ScoringSystem.Data.Entities;
using ScoringSystem.Models;

namespace ScoringSystem.Mappers
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
                    questionModel = new BoolQuestionModel()
                    {
                        Coefficient = question.TrueCoefficient.Value
                    };

                }
                else
                {
                    questionModel = new VariableQuestionModel
                    {
                        Answers = answers
                            .Where(a => a.QuestionId == question.Id)
                            .Select(AnswerMapper.MapToModel).ToList()
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