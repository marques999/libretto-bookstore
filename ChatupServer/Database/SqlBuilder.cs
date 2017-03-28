using System.Collections.Generic;
using System.Linq;

namespace ChatupNET.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal class SqlBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<string> _selectedTables = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        private readonly List<SqlColumn> _selectedColumns = new List<SqlColumn>();

        /// <summary>
        /// 
        /// </summary>
        private readonly WhereStatement _whereStatement = new WhereStatement();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public SqlBuilder Column(string column)
        {
            _selectedColumns.Add(new SqlColumn
            {
                Name = column,
                Alias = null
            });

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public SqlBuilder FromTable(string table)
        {
            _selectedTables.Add(table);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="operator"></param>
        /// <param name="compareValue"></param>
        /// <returns></returns>
        public SqlBuilder Where(string field, Comparison @operator, object compareValue)
        {
            _whereStatement.Add(new WhereClause(field, @operator, compareValue), 1);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BuildQuery()
        {
            var query = "SELECT ";

            if (_selectedColumns.Count == 0)
            {
                if (_selectedTables.Count == 1)
                {
                    query += _selectedTables[0] + ".";
                }

                query += "*";
            }
            else
            {
                query = _selectedColumns.Aggregate(query, (current, currentColumn) => current + (currentColumn.Alias == null ? currentColumn.Name + ',' : currentColumn.Name + " AS " + currentColumn.Alias + ','));
                query = query.TrimEnd(',');
                query += ' ';
            }

            if (_selectedTables.Count > 0)
            {
                query += " FROM ";
                query = _selectedTables.Aggregate(query, (current, tableName) => current + (tableName + ','));
                query = query.TrimEnd(',');
                query += ' ';
            }

            if (_whereStatement.ClauseLevels > 0)
            {
                query += " WHERE " + _whereStatement.BuildWhereStatement();
            }

            return query;
        }
    }
}