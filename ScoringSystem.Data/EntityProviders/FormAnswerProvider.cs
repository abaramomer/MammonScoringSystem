using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ScoringSystem.Data.Entities;
using ScoringSystem.Data.Extensions;

namespace ScoringSystem.Data.EntityProviders
{
    public class FormAnswerProvider : EntityProviderBase<FormAnswer>
    {
        public override List<string> Columns 
        { 
            get
            {
                return new List<string>
                {
                    "id",
                    "form_id",
                    "question_id",
                    "answer"
                };
            } 
        }

        public override string TableName 
        { 
            get { return "form_answers"; } 
        }

        protected override Dictionary<string, object> GetColumnValues(FormAnswer entity)
        {
            return new Dictionary<string, object>
            {
                {"form_id", entity.FormId},
                {"question_id", entity.QuestionId },
                {"answer", entity.Answer}
            };
        }

        protected override FormAnswer EntityFromReader(MySqlDataReader dataReader)
        {
            return new FormAnswer
            {
                Id = dataReader.GetValue<int>("id"),
                QuestionId = dataReader.GetValue<int>("question_id"),
                Answer = dataReader.GetValue<int>("answer")
            };
        }
    }
}