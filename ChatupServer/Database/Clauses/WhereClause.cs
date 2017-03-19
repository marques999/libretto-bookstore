using System.Collections.Generic;

using ChatupNET.Database.Enums;

namespace ChatupNET.Database
{
    class WhereClause
    {
        /// <summary>
        /// 
        /// </summary>
        private object m_Value;

        /// <summary>
        /// 
        /// </summary>
        private string m_FieldName;

        internal struct SubClause
        {
            /// <summary>
            /// 
            /// </summary>
            public object Value;

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
            get
            {
                return m_FieldName;
            }
            private set
            {
                m_FieldName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Comparison m_ComparisonOperator;

        /// <summary>
        /// 
        /// </summary>
        public Comparison ComparisonOperator
        {
            get
            {
                return m_ComparisonOperator;
            }
            private set
            {
                m_ComparisonOperator = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Value
        {
            get
            {
                return m_Value;
            }
            private set
            {
                m_Value = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="firstCompareOperator"></param>
        /// <param name="firstCompareValue"></param>
        public WhereClause(string field, Comparison firstCompareOperator, object firstCompareValue)
        {
            m_FieldName = field;
            m_Value = firstCompareValue;
            m_ComparisonOperator = firstCompareOperator;
            SubClauses = new List<SubClause>();
        }
    }
}