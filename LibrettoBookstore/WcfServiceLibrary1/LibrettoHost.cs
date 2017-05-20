using System;
using System.Collections;
using System.Linq;
using System.Messaging;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.ServiceModel;

using Libretto;
using Libretto.Warehouse;

using LibrettoWCF.Properties;
using LibrettoWCF.WarehouseReference;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    public class LibrettoHost
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
        public static MessageQueue InvoiceQueue
        {
            get;
        } = MessagingCommon.InitializeInvoiceQueue();

        /// <summary>
        /// 
        /// </summary>
        private static WarehouseServiceClient _warehouseProxy;

        /// <summary>
        /// 
        /// </summary>
        public static WarehouseServiceClient WarehouseService => _warehouseProxy ?? (_warehouseProxy = new WarehouseServiceClient());

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

            ChannelServices.RegisterChannel(new TcpChannel(new Hashtable
            {
                {"port", WarehouseCommon.BookstorePort}
            }, new BinaryClientFormatterSinkProvider(), new BinaryServerFormatterSinkProvider
            {
                TypeFilterLevel = TypeFilterLevel.Full
            }), false);

            try
            {
                Bookstore.Open();
                RemotingConfiguration.RegisterActivatedServiceType(typeof(IBookstoreRemoting));
                RemotingServices.Marshal(new BookstoreRemoting(), WarehouseCommon.BookstoreEndpoint);
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