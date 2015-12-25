using System;

namespace ScoringSystem.Data.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }

        public double? TrueCoefficient { get; set; }

        public QuestionType QuestionType { get; set; }
    } 
}
