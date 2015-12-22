using System;

namespace ScoringSystem.Data
{
    public static class EntityCreator
    {
        public static Answer Answer(string text = null, int coefficient = 0)
        {
            return new Answer
            {
                Id = Guid.NewGuid(),
                Coefficient = coefficient,
                Text = text
            };
        }
    }
}