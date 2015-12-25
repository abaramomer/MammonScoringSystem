using System.Collections.Generic;
using System.Text;
using ScoringSystem.Data.EntityProviders;

namespace ScoringSystem.Data
{
    public class QueryBuilder
    {
        private const string SelectStatement = "SELECT";
        private const string FromStatement = "FROM";
        private const string WhereStatement = "WHERE";

        private readonly Dictionary<SqlOperator, string> sqlOperators = new Dictionary<SqlOperator, string>()
        {
            {SqlOperator.Equal, "="},
            {SqlOperator.LessThan, "<"}
        };

        public string SelectQuery(IEntityProvider provider, Condition condition)
        {
            var query = new StringBuilder();

            query.Append(GetSelectStatement(provider));

            if(condition != null)
            {
                query.Append(string.Format("{0} {1}", WhereStatement, GetSqlCondition(condition)));
            }

            return query.ToString();
        }

        private string GetSelectStatement(IEntityProvider provider)
        {
            var columns = string.Join(",", provider.Columns);

            return string.Format("{0} {1} {2} {3}",
               SelectStatement, columns, FromStatement,  provider.TableName);
        }

        private string GetSqlCondition(Condition condition)
        {
            return string.Format("{0} {1} {2}", condition.Column, sqlOperators[SqlOperator.Equal], condition.Value);
        }
    }
}