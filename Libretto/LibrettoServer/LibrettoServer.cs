using System;
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
        public static SqlConnection Database
        {
            get;
        } = new SqlConnection();

        /// <summary>
        /// 
        /// </summary>
        private static void Main(string[] args)
        {
            Console.WriteLine(@"Test");
        }
    }
}