using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ScoringSystem.Data.Entities;
using ScoringSystem.Data.Extensions;

namespace ScoringSystem.Data.EntityProviders
{
    public class AnswerProvider : EntityProviderBase<Answer>
    {
        public override List<string> Columns 
        { 
            get
            {
                return new List<string>()
                {
                    "id",
                    "text",
                    "coefficient",
                    "question_id"
                };
            } 
        }

        public override string TableName 
        { 
            get { return "answers"; } 
        }

        protected override Dictionary<string, object> GetColumnValues(Answer entity)
        {
            return new Dictionary<string, object>()
            {
                {"coefficient", entity.Coefficient}
            };
        }

        protected override Answer EntityFromReader(MySqlDataReader dataReader)
        {
            return new Answer
            {
                Id = dataReader.GetValue<Int32>("id"),
                Text = dataReader.GetValue<string>("text"),
                Coefficient = dataReader.GetValue<double>("coefficient"),
                QuestionId = dataReader.GetValue<int>("question_id")
            };
        }
    }
}