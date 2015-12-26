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
                var question = Repository.Get<Question>(Condition.IdentityCondition(formAnswer.QuestionId)).Single();

                if(question.QuestionType == QuestionType.Bool)
                {
                    var coef = formAnswer.Answer == 0 ? - question.TrueCoefficient : question.TrueCoefficient;
                    sum += coef ?? 0;
                }
                else
                {
                    var answer = Repository.Get<Answer>(Condition.IdentityCondition(formAnswer.Answer)).Single();
                    sum += answer.Coefficient;
                }
            }

            return sum;
        }

        public double GetActualClientScores(int clientId)
        {
            return GetActualForm(clientId).Scores;
        }

        public object GetClientAnswers(int clientId)
        {
            var form = GetActualForm(clientId);

            var answers = Repository.Get<FormAnswer>(Condition.Create("form_id", form.Id));

            var clientAnswers = new List<ClientAnswerModel>();

            foreach (var formAnswer in answers)
            {
                var question = Repository.Get<Question>(Condition.IdentityCondition(formAnswer.QuestionId)).Single();
                
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
                    var answer = Repository.Get<Answer>(Condition.IdentityCondition(formAnswer.Answer)).Single();

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

            return clientForms.OrderByDescending(f => f.FinishDate).FirstOrDefault();
        }
    }
}