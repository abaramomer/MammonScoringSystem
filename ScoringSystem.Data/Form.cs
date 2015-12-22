using System;

namespace ScoringSystem.Data
{
    public class Form : BaseEntity
    {
        public Guid ClientId { get; set; }

        public DateTime FinishDate { get; set; }
    }
}