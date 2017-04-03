using System.Collections.Generic;

namespace ChatupNET.Database
{
    /// <summary>
    ///
    /// </summary>
    internal class WhereClause
    {
        /// <summary>
        ///
        /// </summary>
        internal struct SubClause
        {
            /// <summary>
            ///
            /// </summary>
            /// <param name="logic"></param>
            /// <param name="compareOperator"></param>
            /// <param name="compareValue"></param>
            public SubClause(LogicOperator logic, Comparison compareOperator, object compareValue)
            {
                Value = compareValue;
                LogicOperator = logic;
                ComparisonOperator = compareOperator;
            }

            /// <summary>
            ///
            /// </summary>
            public object Value
            {
                get;
            }

            /// <summary>
            ///
            /// </summary>
            public LogicOperator LogicOperator
            {
                get;
            }

            /// <summary>
            ///
            /// </summary>
            public Comparison ComparisonOperator
            {
                get;
            }
        }

        /// <summary>
        ///
        /// </summary>
        internal List<SubClause> SubClauses;

        /// <summary>
        ///
        /// </summary>
        public object Value
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public string FieldName
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public Comparison ComparisonOperator
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="field"></param>
        /// <param name="firstCompareOperator"></param>
        /// <param name="firstCompareValue"></param>
        public WhereClause(string field, Comparison firstCompareOperator, object firstCompareValue)
        {
            FieldName = field;
            Value = firstCompareValue;
            SubClauses = new List<SubClause>();
            ComparisonOperator = firstCompareOperator;
        }
    }
}