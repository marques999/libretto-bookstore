using System;
using System.Data.Common;
using System.Collections.Generic;

namespace ChatupNET.Database
{
    class WhereStatement : List<List<WhereClause>>
    {
        /// <summary>
        /// 
        /// </summary>
        public int ClauseLevels
        {
            get
            {
                return Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        private void AssertLevelExistance(int level)
        {
            if (Count < (level - 1))
            {
                throw new Exception("Level " + level + " not allowed because level " + (level - 1) + " does not exist.");
            }
            else if (Count < level)
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
            var NewWhereClause = new WhereClause(field, @operator, compareValue);
            AddWhereClauseToLevel(NewWhereClause, level);
            return NewWhereClause;
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
            string Result = "";

            foreach (var WhereStatement in this)
            {
                string LevelWhere = "";

                foreach (var Clause in WhereStatement)
                {
                    string WhereClause = "";

                    if (useCommandObject)
                    {
                        string parameterName = string.Format(
                            "@p{0}_{1}",
                            usedDbCommand.Parameters.Count + 1,
                            Clause.FieldName.Replace('.', '_')
                            );

                        var parameter = usedDbCommand.CreateParameter();

                        parameter.ParameterName = parameterName;
                        parameter.Value = Clause.Value;
                        usedDbCommand.Parameters.Add(parameter);
                        WhereClause += CreateComparisonClause(Clause.FieldName, Clause.ComparisonOperator, new SqlLiteral(parameterName));
                    }
                    else
                    {
                        WhereClause = CreateComparisonClause(Clause.FieldName, Clause.ComparisonOperator, Clause.Value);
                    }

                    foreach (WhereClause.SubClause SubWhereClause in Clause.SubClauses)
                    {
                        switch (SubWhereClause.LogicOperator)
                        {
                        case LogicOperator.And:
                            WhereClause += " AND ";
                            break;
                        case LogicOperator.Or:
                            WhereClause += " OR ";
                            break;
                        }

                        if (useCommandObject)
                        {
                            string parameterName = string.Format(
                                "@p{0}_{1}",
                                usedDbCommand.Parameters.Count + 1,
                                Clause.FieldName.Replace('.', '_')
                                );

                            var parameter = usedDbCommand.CreateParameter();

                            parameter.ParameterName = parameterName;
                            parameter.Value = SubWhereClause.Value;
                            usedDbCommand.Parameters.Add(parameter);
                            WhereClause += CreateComparisonClause(Clause.FieldName, SubWhereClause.ComparisonOperator, new SqlLiteral(parameterName));
                        }
                        else
                        {
                            WhereClause += CreateComparisonClause(Clause.FieldName, SubWhereClause.ComparisonOperator, SubWhereClause.Value);
                        }
                    }

                    LevelWhere += "(" + WhereClause + ") AND ";
                }

                LevelWhere = LevelWhere.Substring(0, LevelWhere.Length - 5);

                if (WhereStatement.Count > 1)
                {
                    Result += " (" + LevelWhere + ") ";
                }
                else
                {
                    Result += " " + LevelWhere + " ";
                }

                Result += " OR";
            }

            return Result.Substring(0, Result.Length - 2);
        }

        internal static string CreateComparisonClause(string fieldName, Comparison comparisonOperator, object value)
        {
            string Output = "";

            if (value != null && value != DBNull.Value)
            {
                switch (comparisonOperator)
                {
                case Comparison.Equals:
                    Output = fieldName + " = " + FormatSQLValue(value);
                    break;
                case Comparison.NotEquals:
                    Output = fieldName + " <> " + FormatSQLValue(value);
                    break;
                case Comparison.GreaterThan:
                    Output = fieldName + " > " + FormatSQLValue(value);
                    break;
                case Comparison.GreaterOrEquals:
                    Output = fieldName + " >= " + FormatSQLValue(value);
                    break;
                case Comparison.LessThan:
                    Output = fieldName + " < " + FormatSQLValue(value);
                    break;
                case Comparison.LessOrEquals:
                    Output = fieldName + " <= " + FormatSQLValue(value);
                    break;
                case Comparison.Like:
                    Output = fieldName + " LIKE " + FormatSQLValue(value);
                    break;
                case Comparison.NotLike:
                    Output = "NOT " + fieldName + " LIKE " + FormatSQLValue(value);
                    break;
                case Comparison.In:
                    Output = fieldName + " IN (" + FormatSQLValue(value) + ")";
                    break;
                }
            }
            else
            {
                if ((comparisonOperator != Comparison.Equals) && (comparisonOperator != Comparison.NotEquals))
                {
                    throw new Exception("Cannot use comparison operator " + comparisonOperator.ToString() + " for NULL values.");
                }
                else
                {
                    switch (comparisonOperator)
                    {
                    case Comparison.Equals:
                        Output = fieldName + " IS NULL";
                        break;
                    case Comparison.NotEquals:
                        Output = "NOT " + fieldName + " IS NULL";
                        break;
                    }
                }
            }

            return Output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="someValue"></param>
        /// <returns></returns>
        internal static string FormatSQLValue(object someValue)
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