using System;

namespace ScoringSystem.Data
{
    public class Form : BaseEntity
    {
        public int ClientId { get; set; }

        public DateTime FinishDate { get; set; }
    }
}