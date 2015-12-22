using System.Data.Entity;

namespace ScoringSystem.Data
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext() :
            base()
        {
            Database.SetInitializer(new QuestionInitializer());
        }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Form> Forms { get; set; }

        public DbSet<FormAnswer> FormAnswers { get; set; }
    }
}