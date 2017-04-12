using System;

namespace Libretto.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseCommon
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly ushort RemotingPort = 13333;

        /// <summary>
        /// 
        /// </summary>
        public static readonly string RemotingEndpoint = "warehouse.rem";

        /// <summary>
        /// 
        /// </summary>
        public static string RemotingAddress => $"tcp://localhost:{RemotingPort}/{RemotingEndpoint}";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string BooksFilename = $"{AppDomain.CurrentDomain.BaseDirectory}WarehouseBooks.xml";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string TransactionsFilename = $"{AppDomain.CurrentDomain.BaseDirectory}WarehouseTransactions.xml";
    }
}