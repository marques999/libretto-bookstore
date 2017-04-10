using System.Data.SqlClient;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal class LibrettoServer
    {
        /// <summary>
        /// 
        /// </summary>
        public SqlConnection Database
        {
            get;
        } = new SqlConnection();

        /// <summary>
        /// 
        /// </summary>
        private static LibrettoServer _instance;

        /// <summary>
        /// 
        /// </summary>
        public static LibrettoServer Instance => _instance ?? (_instance = new LibrettoServer());

        /// <summary>
        /// 
        /// </summary>
        private static void Main(string[] args)
        {
        }
    }
}