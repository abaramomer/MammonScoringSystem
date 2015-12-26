namespace ScoringSystem.Data.Entities
{
    public class FormAnswer : BaseEntity
    {
        public int FormId { get; set; }

        public int QuestionId { get; set; }

        public int Answer { get; set; }
    }
}