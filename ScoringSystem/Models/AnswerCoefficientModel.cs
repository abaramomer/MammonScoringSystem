namespace ScoringSystem.Models
{
    public class AnswerCoefficientModel
    {
        public int QuestionId { get; set; }

        public int? AnswerId { get; set; }

        public double Coefficient { get; set; }
    }
}