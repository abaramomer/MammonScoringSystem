using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ScoringSystem.Data.Entities;
using ScoringSystem.Data.Extensions;

namespace ScoringSystem.Data.EntityProviders
{
    public class QuestionProvider : EntityProviderBase<Question>
    {
        public override List<string> Columns 
        { 
            get
            {
                return new List<string>
                {
                    "id",
                    "text",
                    "true_coefficient",
                    "question_type"
                };
            }
        }

        public override string TableName { get { return "questions"; } }

        protected override Dictionary<string, object> GetColumnValues(Question entity)
        {
            return new Dictionary<string, object>()
            {
                {"true_coefficient", entity.TrueCoefficient}
            };
        }

        protected override Question EntityFromReader(MySqlDataReader dataReader)
        {
            return new Question
            {
                Id = dataReader.GetValue<Int32>("id"),
                Text = dataReader.GetValue<string>("text"),
                TrueCoefficient = dataReader["true_coefficient"] is DBNull 
                    ? null
                    : dataReader.GetValue<double?>("true_coefficient"),

                QuestionType = (QuestionType)dataReader.GetValue<Int16>("question_type")
            };
        }
    }
}