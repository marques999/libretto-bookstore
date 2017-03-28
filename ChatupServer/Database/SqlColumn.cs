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
        public string Name;

        /// <summary>
        /// 
        /// </summary>
        public string Alias;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramAlias"></param>
        public SqlColumn(string paramName, string paramAlias)
        {
            Name = paramName;
            Alias = paramAlias;
        }
    }
}