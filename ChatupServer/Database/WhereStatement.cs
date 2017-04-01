using System;
using System.Data.Common;
using System.Collections.Generic;

namespace ChatupNET.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal class WhereStatement : List<List<WhereClause>>
    {
        /// <summary>
        /// 
        /// </summary>
        public int ClauseLevels => Count;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        private void AssertLevelExistance(int level)
        {
            if (Count < level - 1)
            {
                throw new Exception("Level " + level + " not allowed because level " + (level - 1) + " does not exist.");
            }

            if (Count < level)
            {
                Add(new List<WhereClause>());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clause"></param>
        /// <param name="level"></param>
        public void Add(WhereClause clause, int level)
        {
            AddWhereClauseToLevel(clause, level);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="operator"></param>
        /// <param name="compareValue"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public WhereClause Add(string field, Comparison @operator, object compareValue, int level)
        {
            var newWhereClause = new WhereClause(field, @operator, compareValue);
            AddWhereClauseToLevel(newWhereClause, level);
            return newWhereClause;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clause"></param>
        /// <param name="level"></param>
        private void AddWhereClauseToLevel(WhereClause clause, int level)
        {
            AssertLevelExistance(level);
            this[level - 1].Add(clause);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BuildWhereStatement()
        {
            DbCommand dummyCommand = null;
            return BuildWhereStatement(false, ref dummyCommand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="useCommandObject"></param>
        /// <param name="usedDbCommand"></param>
        /// <returns></returns>
        public string BuildWhereStatement(bool useCommandObject, ref DbCommand usedDbCommand)
        {
            var result = "";

            foreach (var whereStatement in this)
            {
                var levelWhere = "";

                foreach (var clause in whereStatement)
                {
                    var whereClause = "";

                    if (useCommandObject)
                    {
                        var parameterName = $"@p{usedDbCommand.Parameters.Count + 1}_{clause.FieldName.Replace('.', '_')}";
                        var parameter = usedDbCommand.CreateParameter();

                        parameter.ParameterName = parameterName;
                        parameter.Value = clause.Value;
                        usedDbCommand.Parameters.Add(parameter);
                        whereClause += CreateComparisonClause(clause.FieldName, clause.ComparisonOperator, new SqlLiteral(parameterName));
                    }
                    else
                    {
                        whereClause = CreateComparisonClause(clause.FieldName, clause.ComparisonOperator, clause.Value);
                    }

                    foreach (WhereClause.SubClause subWhereClause in clause.SubClauses)
                    {
                        switch (subWhereClause.LogicOperator)
                        {
                        case LogicOperator.And:
                            whereClause += " AND ";
                            break;
                        case LogicOperator.Or:
                            whereClause += " OR ";
                            break;
                        }

                        if (useCommandObject)
                        {
                            var parameterName = $"@p{usedDbCommand.Parameters.Count + 1}_{clause.FieldName.Replace('.', '_')}";
                            var parameter = usedDbCommand.CreateParameter();

                            parameter.ParameterName = parameterName;
                            parameter.Value = subWhereClause.Value;
                            usedDbCommand.Parameters.Add(parameter);
                            whereClause += CreateComparisonClause(clause.FieldName, subWhereClause.ComparisonOperator, new SqlLiteral(parameterName));
                        }
                        else
                        {
                            whereClause += CreateComparisonClause(clause.FieldName, subWhereClause.ComparisonOperator, subWhereClause.Value);
                        }
                    }

                    levelWhere += "(" + whereClause + ") AND ";
                }

                levelWhere = levelWhere.Substring(0, levelWhere.Length - 5);

                if (whereStatement.Count > 1)
                {
                    result += " (" + levelWhere + ") ";
                }
                else
                {
                    result += " " + levelWhere + " ";
                }

                result += " OR";
            }

            return result.Substring(0, result.Length - 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="comparisonOperator"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string CreateComparisonClause(string fieldName, Comparison comparisonOperator, object value)
        {
            var output = "";

            if (value != null && value != DBNull.Value)
            {
                switch (comparisonOperator)
                {
                case Comparison.Equals:
                    output = fieldName + " = " + FormatSqlValue(value);
                    break;
                case Comparison.NotEquals:
                    output = fieldName + " <> " + FormatSqlValue(value);
                    break;
                case Comparison.GreaterThan:
                    output = fieldName + " > " + FormatSqlValue(value);
                    break;
                case Comparison.GreaterOrEquals:
                    output = fieldName + " >= " + FormatSqlValue(value);
                    break;
                case Comparison.LessThan:
                    output = fieldName + " < " + FormatSqlValue(value);
                    break;
                case Comparison.LessOrEquals:
                    output = fieldName + " <= " + FormatSqlValue(value);
                    break;
                case Comparison.Like:
                    output = fieldName + " LIKE " + FormatSqlValue(value);
                    break;
                case Comparison.NotLike:
                    output = "NOT " + fieldName + " LIKE " + FormatSqlValue(value);
                    break;
                case Comparison.In:
                    output = fieldName + " IN (" + FormatSqlValue(value) + ")";
                    break;
                }
            }
            else
            {
                if ((comparisonOperator != Comparison.Equals) && (comparisonOperator != Comparison.NotEquals))
                {
                    throw new Exception("Cannot use comparison operator " + comparisonOperator.ToString() + " for NULL values.");
                }

                switch (comparisonOperator)
                {
                case Comparison.Equals:
                    output = fieldName + " IS NULL";
                    break;
                case Comparison.NotEquals:
                    output = "NOT " + fieldName + " IS NULL";
                    break;
                }
            }

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="someValue"></param>
        /// <returns></returns>
        internal static string FormatSqlValue(object someValue)
        {
            if (someValue == null)
            {
                return "NULL";
            }

            switch (someValue.GetType().Name)
            {
            case "String":
                return "'" + ((string)someValue).Replace("'", "''") + "'";
            case "DateTime":
                return "'" + ((DateTime)someValue).ToString("yyyy/MM/dd hh:mm:ss") + "'";
            case "DBNull":
                return "NULL";
            case "Boolean":
                return (bool)someValue ? "1" : "0";
            case "SqlLiteral":
                return ((SqlLiteral)someValue).Value;
            }

            return someValue.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement1"></param>
        /// <param name="statement2"></param>
        /// <returns></returns>
        public static WhereStatement CombineStatements(WhereStatement statement1, WhereStatement statement2)
        {
            var result = Copy(statement1);

            for (int i = 0; i < statement2.ClauseLevels; i++)
            {
                var level = statement2[i];

                foreach (var clause in level)
                {
                    for (int j = 0; j < result.ClauseLevels; j++)
                    {
                        result.AddWhereClauseToLevel(clause, j);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public static WhereStatement Copy(WhereStatement statement)
        {
            int currentLevel = 0;
            var result = new WhereStatement();

            foreach (var level in statement)
            {
                currentLevel++;
                result.Add(new List<WhereClause>());

                foreach (var clause in statement[currentLevel - 1])
                {
                    var clauseCopy = new WhereClause(clause.FieldName, clause.ComparisonOperator, clause.Value);

                    foreach (var subClause in clause.SubClauses)
                    {
                        clauseCopy.SubClauses.Add(new WhereClause.SubClause(subClause.LogicOperator, subClause.ComparisonOperator, subClause.Value));
                    }

                    result[currentLevel - 1].Add(clauseCopy);
                }
            }

            return result;
        }
    }
}