using System;

namespace ScoringSystem.Data
{
    public class Answer : BaseEntity
    {
        public Guid QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public string Text { get; set; }

        public int Coefficient { get; set; }
    }
}