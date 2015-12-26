using ScoringSystem.Data.Entities;
using ScoringSystem.Models;

namespace ScoringSystem.Mappers
{
    public class AnswerMapper
    {
         public static AnswerModel MapToModel(Answer answer)
         {
             return new AnswerModel
             {
                 Coefficient = answer.Coefficient,
                 Id = answer.Id,
                 Text = answer.Text
             };
         }
    }
}