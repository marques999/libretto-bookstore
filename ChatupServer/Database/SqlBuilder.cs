using System;
using System.Collections.Generic;

using ChatupNET.Database.Enums;

namespace ChatupNET.Database
{
    class SqlBuilder
    {
        protected bool _distinct = false;
        protected TopClause _topClause = new TopClause(100, TopUnit.Percent);
        private List<SqlColumn> _selectedColumns = new List<SqlColumn>();
        protected List<string> _selectedTables = new List<string>();
        protected WhereStatement _whereStatement = new WhereStatement();
        protected List<string> _groupByColumns = new List<string>();
        protected WhereStatement _havingStatement = new WhereStatement();

        public SqlBuilder()
        {
        }

        public SqlBuilder Column(string column)
        {
            return Column(column, null);
        }

        public SqlBuilder Column(string column, string columnAs)
        {
            _selectedColumns.Add(new SqlColumn
            {
                Name = column,
                Alias = columnAs
            });

            return this;
        }

        public SqlBuilder Columns(params SqlColumn[] columns)
        {
            _selectedColumns.Clear();
            _selectedColumns.AddRange(columns);

            return this;
        }

        public SqlBuilder FromTable(string table)
        {
            _selectedTables.Add(table);

            return this;
        }

        public SqlBuilder Where(string field, Comparison @operator, object compareValue)
        {
            Where(field, @operator, compareValue, 1);

            return this;
        }

        public WhereClause Where(string field, Comparison @operator, object compareValue, int level)
        {
            WhereClause NewWhereClause = new WhereClause(field, @operator, compareValue);
            _whereStatement.Add(NewWhereClause, level);
            return NewWhereClause;
        }

        public string BuildQuery()
        {
            string Query = "SELECT ";

            if (_distinct)
            {
                Query += "DISTINCT ";
            }

            if (!(_topClause.Quantity == 100 & _topClause.Unit == TopUnit.Percent))
            {
                Query += "TOP " + _topClause.Quantity;

                if (_topClause.Unit == TopUnit.Percent)
                {
                    Query += " PERCENT";
                }

                Query += " ";
            }

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

            if (_groupByColumns.Count > 0)
            {
                Query += " GROUP BY ";

                foreach (string Column in _groupByColumns)
                {
                    Query += Column + ',';
                }

                Query = Query.TrimEnd(',');
                Query += ' ';
            }

            if (_havingStatement.ClauseLevels > 0)
            {
                if (_groupByColumns.Count == 0)
                {
                    throw new Exception("Having statement was set without Group By");
                }

                Query += " HAVING " + _havingStatement.BuildWhereStatement();
            }

            return Query;
        }
    }
}