using System;

namespace ScoringSystem
{
    public class ScoringSystemException : Exception
    {
         public ScoringSystemException(string message)
             :base(message)
        {

        }
    }
}