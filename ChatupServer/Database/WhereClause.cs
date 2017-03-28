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
                LogicOperator = logic;
                ComparisonOperator = compareOperator;
                Value = compareValue;
            }

            /// <summary>
            ///
            /// </summary>
            public object Value;

            /// <summary>
            ///
            /// </summary>
            public LogicOperator LogicOperator;

            /// <summary>
            ///
            /// </summary>
            public Comparison ComparisonOperator;
        }

        /// <summary>
        ///
        /// </summary>
        internal List<SubClause> SubClauses;

        /// <summary>
        ///
        /// </summary>
        public string FieldName
        {
            get;
            private set;
        }

        /// <summary>
        ///
        /// </summary>
        public Comparison ComparisonOperator
        {
            get;
            private set;
        }

        /// <summary>
        ///
        /// </summary>
        public object Value
        {
            get;
            private set;
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
            ComparisonOperator = firstCompareOperator;
            SubClauses = new List<SubClause>();
        }
    }
}