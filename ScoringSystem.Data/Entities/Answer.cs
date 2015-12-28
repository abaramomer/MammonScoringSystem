namespace ScoringSystem.Data.Entities
{
    public class Answer : BaseEntity
    {
        public int QuestionId { get; set; }

        public string Text { get; set; }

        public double Coefficient { get; set; }
    }
}