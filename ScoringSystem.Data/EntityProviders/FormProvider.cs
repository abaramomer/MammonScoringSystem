using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ScoringSystem.Data.Entities;
using ScoringSystem.Data.Extensions;

namespace ScoringSystem.Data.EntityProviders
{
    public class FormProvider : EntityProviderBase<Form>
    {
        public override List<string> Columns 
        { 
            get
            {
                return new List<string>()
                {
                    "id",
                    "finish_date",
                    "client_id",
                    "scores"
                };
            } 
        }

        public override string TableName 
        { 
            get { return "forms"; } 
        }

        protected override Dictionary<string, object> GetColumnValues(Form entity)
        {
            return new Dictionary<string, object>
            {
                {"client_id", entity.ClientId},
                {"finish_date", "'" + entity.FinishDate.ToString("u").Replace("Z" ,"") + "'"},
                {"scores", entity.Scores}
            };
        }

        protected override Form EntityFromReader(MySqlDataReader dataReader)
        {
            return new Form
            {
                Id = dataReader.GetValue<int>("id"),
                FinishDate = dataReader.GetValue<DateTime>("finish_date"),
                ClientId = dataReader.GetValue<int>("client_id"),
                Scores = dataReader.GetValue<double>("scores")
            };
        
        }
    }
}