using System;

namespace ScoringSystem.Data.Entities
{
    public class FormAnswer : BaseEntity
    {
        public int FormId { get; set; }

        public int QuestionId { get; set; }

        public string Answer { get; set; }
    }
}