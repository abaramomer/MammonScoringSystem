using System.Collections.Generic;
using System.Text;
using ScoringSystem.Data.EntityProviders;

namespace ScoringSystem.Data
{
    public class QueryBuilder
    {
        private const string UpdateStatement = "UPDATE";
        private const string SetStatement = "SET";
        private const string SelectStatement = "SELECT";
        private const string FromStatement = "FROM";
        private const string WhereStatement = "WHERE";
        private const string InsertStatement = "INSERT INTO";
        private const string InsertValuesStatement = "VALUES";

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
                query.AppendFormat(" {0} {1}", WhereStatement, GetSqlCondition(condition));
            }

            return query.ToString();
        }

        public string UpdateQuery(IEntityProvider provider, Condition condition, Dictionary<string, object> values)
        {
            var query = new StringBuilder();

            query.AppendFormat("{0} {1} {2}", UpdateStatement, provider.TableName, SetStatement);

            foreach (var value in values)
            {
                query.AppendFormat(" {0}={1},", value.Key, value.Value);
            }

            //remove last comma
            query.Remove(query.Length - 1, 1);

            query.AppendFormat(" {0} {1}", WhereStatement, GetSqlCondition(condition));

            return query.ToString();
        }

        public string InsertQuery(IEntityProvider provider, Dictionary<string, object> values)
        {
            var columns = new StringBuilder("(");
            var columnValues = new StringBuilder("(");

            foreach (var value in values)
            {
                columns.Append(value.Key + ",");
                columnValues.AppendFormat(value.Value + ",");
            }

            columns.Replace(",", ")", columns.Length - 1, 1);
            columnValues.Replace(",", ")", columnValues.Length - 1, 1);

            return string.Format("{0} {1} {2} {3} {4}", InsertStatement,
                provider.TableName, columns, InsertValuesStatement, columnValues);
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