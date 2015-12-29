using System;
using System.Collections.Generic;
using System.Linq;
using ScoringSystem.Data;
using ScoringSystem.Data.Entities;
using ScoringSystem.Data.ExternalData;
using ScoringSystem.Mappers;
using ScoringSystem.Models;

namespace ScoringSystem.Services
{
    public class FormService : BaseService
    {
        private readonly ScoreService scoreService;
        private readonly MammonBankRepository mammonBankRepository;

        public FormService()
        {
            scoreService = new ScoreService();
            mammonBankRepository = new MammonBankRepository();
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
                ClientId = clientId,//mammonBankRepository.ClientIdByLink(clientLink),
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
                    var answer = Repository.Get<Answer>(coefficient.AnswerId.Value);

                    answer.Coefficient = coefficient.Coefficient;

                    Repository.InsertOrUpdate(answer);
                }
                else
                {
                    var question = Repository.Get<Question>(coefficient.QuestionId);

                    question.TrueCoefficient = coefficient.Coefficient;

                    Repository.InsertOrUpdate(question);
                }
            }

            Repository.Close();
        }

        public bool IsLinkCorrect(string link)
        {
            int a;

            return Int32.TryParse(link, out a); //mammonBankRepository.ClientIdByLink(link) != -1;
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