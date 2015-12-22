using System.Collections.Generic;

namespace ScoringSystem.Data
{
    public class VariableQuestion : Question
    {
        public virtual List<Answer> Answers { get; set; }
    }
}