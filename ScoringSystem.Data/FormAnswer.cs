using System;

namespace ScoringSystem.Data
{
    public class FormAnswer : BaseEntity
    {
        public Guid FormId { get; set; }

        public virtual Form Form { get; set; }

        public Guid QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public string Answer { get; set; }
    }
}