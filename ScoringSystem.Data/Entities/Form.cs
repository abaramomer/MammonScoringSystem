using System;

namespace ScoringSystem.Data.Entities
{
    public class Form : BaseEntity
    {
        public int ClientId { get; set; }

        public DateTime FinishDate { get; set; }
    }
}