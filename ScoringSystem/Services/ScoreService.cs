using System.Collections.Generic;
using System.Linq;
using ScoringSystem.Data;
using ScoringSystem.Data.Entities;
using ScoringSystem.Models;

namespace ScoringSystem.Services
{
    public class ScoreService : BaseService
    {
        public double CalculateScores(List<FormAnswerModel> formAnswers)
        {
            double sum = 0;
            foreach (var formAnswer in formAnswers)
            {
                var question = Repository.Get<Question>(formAnswer.QuestionId);

                if(question.QuestionType == QuestionType.Bool)
                {
                    var coef = formAnswer.Answer == 0 ? - question.TrueCoefficient : question.TrueCoefficient;
                    sum += coef ?? 0;
                }
                else
                {
                    var answer = Repository.Get<Answer>(formAnswer.Answer);
                    sum += answer.Coefficient;
                }
            }

            return sum > 0 ? sum : 0;
        }

        public double GetActualClientScores(int clientId)
        {
            return GetActualForm(clientId).Scores;
        }

        public List<ClientAnswerModel> GetClientAnswers(int clientId)
        {
            var form = GetActualForm(clientId);

            var answers = Repository.Get<FormAnswer>(Condition.Create("form_id", form.Id));

            var clientAnswers = new List<ClientAnswerModel>();

            foreach (var formAnswer in answers)
            {
                var question = Repository.Get<Question>(formAnswer.QuestionId);
                
                var clientAnswer = new ClientAnswerModel()
                {
                    QuestionText = question.Text
                };

                if(question.QuestionType == QuestionType.Bool)
                {
                    clientAnswer.QuestionAnswer = formAnswer.Answer == 1 ? "Да" : "Нет";
                }
                else
                {
                    var answer = Repository.Get<Answer>(formAnswer.Answer);

                    clientAnswer.QuestionAnswer = answer.Text;
                }

                clientAnswers.Add(clientAnswer);
            }

            Repository.Close();

            return clientAnswers;
        }

        private Form GetActualForm(int clientId)
        {
            var clientForms = Repository.Get<Form>(Condition.Create("client_id", clientId));

            Repository.Close();

            var form = clientForms.OrderByDescending(f => f.FinishDate).FirstOrDefault();

            if(form == null)
            {
                throw new ScoringSystemException("client does not exist or does not have any forms");
            }

            return form;
        }
    }
}