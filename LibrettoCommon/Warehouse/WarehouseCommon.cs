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
        public static readonly short BookstorePort = 14666;

        /// <summary>
        /// 
        /// </summary>
        public static readonly ushort WarehousePort = 13333;

        /// <summary>
        /// 
        /// </summary>
        public static readonly string BookstoreEndpoint = "bookstore.rem";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string WarehouseEndpoint = "warehouse.rem";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string BookstoreAddress = $"tcp://localhost:{BookstorePort}/{BookstoreEndpoint}";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string WarehouseAddress = $"tcp://localhost:{WarehousePort}/{WarehouseEndpoint}";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string TransactionsFilename = $"{AppDomain.CurrentDomain.BaseDirectory}WarehouseTransactions.xml";
    }
}