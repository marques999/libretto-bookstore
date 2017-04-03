namespace ChatupNET.Database
{
    /// <summary>
    ///
    /// </summary>
    internal class SqlLiteral
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        public SqlLiteral(string value)
        {
            Value = value;
        }

        /// <summary>
        ///
        /// </summary>
        public string Value
        {
            get;
        }
    }
}