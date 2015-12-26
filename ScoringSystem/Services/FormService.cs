using System;
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
        private ScoreService scoreService;

        public FormService()
        {
            scoreService = new ScoreService();
        }

        public List<QuestionModel> GetFormQuestions()
        {
            var questions = Repository.Get<Question>(null).ToList();

            var answers = Repository.Get<Answer>(null).ToList();

            Repository.Close();

            return QuestionModelMapper.MapToQuestionModels(questions, answers);
        }

        public double SaveForm(int clientId, List<FormAnswerModel> formAnswers)
        {
            Form form = new Form
            {
                ClientId = clientId,
                FinishDate = DateTime.UtcNow,
                Scores = scoreService.CalculateScores(formAnswers),
            };

            form = Repository.InsertOrUpdate(form);
            
            foreach (var formAnswer in formAnswers)
            {
                SaveFormAnswer(formAnswer, form.Id);
            }

            Repository.Close();

            return form.Scores;
        }

        public void SaveCoefficients(List<AnswerCoefficientModel> answerCoefficients)
        {
            foreach (var coefficient in answerCoefficients)
            {
                if(coefficient.AnswerId.HasValue)
                {
                    var answer = Repository.Get<Answer>(Condition.IdentityCondition(coefficient.AnswerId.Value)).Single();

                    answer.Coefficient = coefficient.Coefficient;

                    Repository.InsertOrUpdate(answer);
                }
                else
                {
                    var question = Repository.Get<Question>(Condition.IdentityCondition(coefficient.QuestionId)).Single();

                    question.TrueCoefficient = coefficient.Coefficient;

                    Repository.InsertOrUpdate(question);
                }
            }

            Repository.Close();
        }

        private void SaveFormAnswer(FormAnswerModel formAnswer, int formId)
        {
            Repository.InsertOrUpdate(new FormAnswer
            {
                QuestionId = formAnswer.QuestionId,
                Answer = formAnswer.Answer,
                FormId = formId
            });
        }
    }
}