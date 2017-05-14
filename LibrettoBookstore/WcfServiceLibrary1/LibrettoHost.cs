using System;
using System.Linq;
using System.Messaging;
using System.ServiceModel;

using Libretto;
using Libretto.Messaging;
using Libretto.Model;
using Libretto.Warehouse;
using LibrettoWCF.Database;
using LibrettoWCF.Tools;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    public class LibrettoHost : MarshalByRefObject, IRemotingService
    {
        /// <summary>
        /// 
        /// </summary>
        private static ServiceHost Webstore
        {
            get;
        } = new ServiceHost(typeof(WebstoreService));

        /// <summary>
        /// 
        /// </summary>
        private static ServiceHost Bookstore
        {
            get;
        } = new ServiceHost(typeof(StoreService));

        /// <summary>
        /// 
        /// </summary>
        public static MessageQueue WarehouseQueue
        {
            get;
        } = MessagingCommon.InitializeWarehouseQueue();

        /// <summary>
        /// 
        /// </summary>
        public static MessageQueue InvoiceQueue
        {
            get;
        } = MessagingCommon.InitializeInvoiceQueue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public Response DispatchOrder(Guid transactionIdentifier)
        {
            var operationResult = LibrettoDatabase.OrderIntegration.UpdateStatus(transactionIdentifier, new DateTime(), Status.Processing);
            return operationResult == Response.Success ? EmailClient.Instance.UpdateStatus(LibrettoDatabase.OrderIntegration.Lookup(transactionIdentifier)) : operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Bookstore.Open();
            Console.WriteLine($@"IStoreService running on port {Bookstore.BaseAddresses.FirstOrDefault()?.Port}...");
            Webstore.Open();
            Console.WriteLine($@"IWebstoreService running on port {Webstore.BaseAddresses.FirstOrDefault()?.Port}...");
            Console.WriteLine(@"Press any key to close.");
            Console.ReadKey(true);
            Bookstore.Close();
            Webstore.Close();
        }
    }
}