using Libretto.Messaging;
using System;
using System.Linq;
using System.Messaging;
using System.ServiceModel;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    public class LibrettoHost
    {

        private static MessageQueue warehouseQ
        {
            get;
            set;
        }
        private static MessageQueue invoiceQ
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            warehouseQ = MessagingCommon.InitializeWarehouseQueue();
            invoiceQ = MessagingCommon.InitializeInvoiceQueue();

            using (var host = new ServiceHost(typeof(WebstoreService)))
            {

                Console.WriteLine("StockService ready. Press any key to close.");
                Console.WriteLine("Running on port " + host.BaseAddresses.FirstOrDefault()?.Port);
                Console.ReadKey(true);
            }
        }

        public static MessageQueue InitializeWarehouseQueue()
        {
            return MessagingCommon.InitializeWarehouseQueue();
        }

        public static MessageQueue InitializeInvoiceQueue()
        {
            return MessagingCommon.InitializeInvoiceQueue();
        }

    }
}