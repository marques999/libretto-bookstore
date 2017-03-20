using System.Collections.Generic;

namespace ChatupNET.Database
{
    class SqlBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        private List<string> _selectedTables = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        private List<SqlColumn> _selectedColumns = new List<SqlColumn>();

        /// <summary>
        /// 
        /// </summary>
        private WhereStatement _whereStatement = new WhereStatement();

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
            string Query = "SELECT ";

            if (_selectedColumns.Count == 0)
            {
                if (_selectedTables.Count == 1)
                {
                    Query += _selectedTables[0] + ".";
                }

                Query += "*";
            }
            else
            {
                foreach (var CurrentColumn in _selectedColumns)
                {
                    if (CurrentColumn.Alias == null)
                    {
                        Query += CurrentColumn.Name + ',';
                    }
                    else
                    {
                        Query += CurrentColumn.Name + " AS " + CurrentColumn.Alias + ',';
                    }
                }

                Query = Query.TrimEnd(',');
                Query += ' ';
            }

            if (_selectedTables.Count > 0)
            {
                Query += " FROM ";

                foreach (string TableName in _selectedTables)
                {
                    Query += TableName + ',';
                }

                Query = Query.TrimEnd(',');
                Query += ' ';
            }

            if (_whereStatement.ClauseLevels > 0)
            {
                Query += " WHERE " + _whereStatement.BuildWhereStatement();
            }

            return Query;
        }
    }
}