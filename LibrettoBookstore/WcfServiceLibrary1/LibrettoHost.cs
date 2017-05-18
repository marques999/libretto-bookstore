using System;
using System.Linq;
using System.Messaging;
using System.ServiceModel;

using Libretto.Messaging;
using Libretto.Model;
using Libretto.Warehouse;

using LibrettoWCF.Database;
using LibrettoWCF.Properties;
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
            return operationResult == Response.Success ? EmailClient.Instance.NotifyUpdate(LibrettoDatabase.OrderIntegration.Lookup(transactionIdentifier)) : operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        private static void LogException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            LogMessage($"{ex.Source}: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="messageParams"></param>
        private static void LogMessage(string messageFormat, params object[] messageParams)
        {
            Console.WriteLine(Resources.LogFormat, DateTime.Now.ToLongTimeString(), string.Format(messageFormat, messageParams));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = Resources.WindowTitle;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine(Resources.Header);

            try
            {
                Bookstore.Open();
                LogMessage("IStoreService running on port {0:D}...", Bookstore.BaseAddresses.FirstOrDefault()?.Port);
                Webstore.Open();
                LogMessage("IWebstoreService running on port {0:D}...", Webstore.BaseAddresses.FirstOrDefault()?.Port);
                LogMessage("Press <any> key to close!");
                Console.ReadKey(true);
                Bookstore.Close();
                Webstore.Close();
            }
            catch (Exception ex)
            {
                LogException(ex);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Red;
                LogMessage(Resources.ExceptionCaught);
            }
        }
    }
}