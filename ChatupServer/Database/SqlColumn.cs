namespace ChatupNET.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal struct SqlColumn
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlName"></param>
        /// <param name="sqlAlias"></param>
        public SqlColumn(string sqlName, string sqlAlias)
        {
            Name = sqlName;
            Alias = sqlAlias;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Alias
        {
            get;
        }
    }
}