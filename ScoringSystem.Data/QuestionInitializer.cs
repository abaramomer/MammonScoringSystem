using System;
using System.Collections.Generic;
using System.Linq;
using ScoringSystem.Data.Entities;

namespace ScoringSystem.Data
{
    internal class QuestionInitializer
    {

        public IEnumerable<Question> GetInitialQuestions()
        {
            yield return new Question
            {
                Text = "Меняли фамилию, имя, отчество",
                TrueCoefficient = -1
            };
            yield return new Question
            {
                Text = "Образование",
                //Answers = new List<Answer>
                //{
                //    //EntityCreator.Answer("Среднеспециальное", 1),
                //    //EntityCreator.Answer("Неоконченное высшее", 3),
                //    //EntityCreator.Answer("Высшее", 7)
                //}
            };
            yield return new Question
            {
                Text = "Семейное положение",
                //Answers = new List<Answer>
                //{
                //    //EntityCreator.Answer(@"Женат/замужем", 5),
                //    //EntityCreator.Answer("Разведен", 2),
                //    //EntityCreator.Answer("Не женат/замужем", 1),
                //    //EntityCreator.Answer(@"Вдовец/вдова", 3)
                //}
            };
        }
    }
}