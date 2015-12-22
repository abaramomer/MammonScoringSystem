using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ScoringSystem.Data
{
    internal class QuestionInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var questions = GetInitialQuestions().ToList();

            foreach (var question in questions)
            {
                question.Id = Guid.NewGuid();

                if(question is VariableQuestion)
                {
                    var variableQuestion = question as VariableQuestion;

                    variableQuestion.Answers.ForEach(a => a.QuestionId = question.Id);
                }
            }

            questions.ForEach(a => context.Questions.Add(a));

            base.Seed(context);
        }

        private IEnumerable<Question> GetInitialQuestions()
        {
            yield return new BoolQuestion()
            {
                Text = "Меняли фамилию, имя, отчество",
                TrueCoefficient = -1
            };
            yield return new VariableQuestion
            {
                Text = "Образование",
                Answers = new List<Answer>
                {
                    EntityCreator.Answer("Среднеспециальное", 1),
                    EntityCreator.Answer("Неоконченное высшее", 3),
                    EntityCreator.Answer("Высшее", 7)
                }
            };
            yield return new VariableQuestion
            {
                Text = "Семейное положение",
                Answers = new List<Answer>
                {
                    EntityCreator.Answer(@"Женат/замужем", 5),
                    EntityCreator.Answer("Разведен", 2),
                    EntityCreator.Answer("Не женат/замужем", 1),
                    EntityCreator.Answer(@"Вдовец/вдова", 3)
                }
            };
        }
    }
}