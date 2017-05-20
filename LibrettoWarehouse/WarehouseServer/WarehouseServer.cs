using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.ServiceModel;
using System.Xml.Serialization;

using Libretto.Properties;
using Libretto.Warehouse;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseServer
    {
        /// <summary>
        /// 
        /// </summary>
        private static WarehouseOrders _orders;

        /// <summary>
        /// 
        /// </summary>
        private static ServiceHost _serviceHost;

        /// <summary>
        /// 
        /// </summary>
        private static WarehouseRemoting _warehouseRemoting;

        /// <summary>
        /// 
        /// </summary>
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(WarehouseOrders));

        /// <summary>
        /// 
        /// </summary>
        private static void SerializeTransactions()
        {
            WarehouseLogger.LogMessage(Resources.SerializationWrite, WarehouseCommon.TransactionsFilename);
            _orders.Serialize(Serializer, WarehouseCommon.TransactionsFilename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<WarehouseOrder> ListOrders()
        {
            return _orders.Orders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseOrder"></param>
        public static void InsertOrder(WarehouseOrder warehouseOrder)
        {
            _orders.Insert(warehouseOrder);
            _warehouseRemoting.InvokeUpsert(warehouseOrder);
            SerializeTransactions();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <param name="orderQuantity"></param>
        /// <param name="orderTotal"></param>
        public static void UpdateOrder(Guid orderIdentifier, int orderQuantity, double orderTotal)
        {
            var orderInformation = _orders.Update(orderIdentifier, orderQuantity, orderTotal);

            if (orderInformation == null)
            {
                return;
            }

            _warehouseRemoting.InvokeUpsert(orderInformation);
            SerializeTransactions();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        public static void DeleteOrder(Guid orderIdentifier)
        {
            if (_orders.Delete(orderIdentifier))
            {
                SerializeTransactions();
            }

            _warehouseRemoting.InvokeDelete(orderIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Main()
        {
            try
            {
                Console.CursorVisible = false;
                Console.Title = Resources.WindowTitle;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine(Resources.Header);

                if (File.Exists(WarehouseCommon.TransactionsFilename))
                {
                    WarehouseLogger.LogMessage(Resources.SerializationRead, WarehouseCommon.TransactionsFilename);

                    using (var reader = new FileStream(WarehouseCommon.TransactionsFilename, FileMode.Open))
                    {
                        _orders = (WarehouseOrders)Serializer.Deserialize(reader) ?? new WarehouseOrders();
                    }

                    WarehouseLogger.LogMessage(Resources.SerializationDone, _orders.Orders.Count, nameof(WarehouseOrders));
                }
                else
                {
                    _orders = new WarehouseOrders();
                    _orders.Serialize(Serializer, WarehouseCommon.TransactionsFilename);
                    WarehouseLogger.LogMessage(Resources.SerializationWrite, WarehouseCommon.TransactionsFilename);
                }

                ChannelServices.RegisterChannel(new TcpChannel(new Hashtable
                {
                    {
                        "port", WarehouseCommon.WarehousePort
                    }
                }, new BinaryClientFormatterSinkProvider(), new BinaryServerFormatterSinkProvider
                {
                    TypeFilterLevel = TypeFilterLevel.Full
                }), false);

                WarehouseLogger.LogMessage(Resources.RemotingRegisterService, nameof(IBookstoreRemoting));
                RemotingConfiguration.RegisterActivatedServiceType(typeof(IBookstoreRemoting));
                WarehouseLogger.LogMessage(Resources.RemotingRegisterService, nameof(IWarehouseRemoting));
                RemotingConfiguration.RegisterActivatedServiceType(typeof(WarehouseServer));
                WarehouseLogger.LogMessage(Resources.RemotingMarshalService, nameof(WarehouseRemoting));
                _warehouseRemoting = new WarehouseRemoting();
                RemotingServices.Marshal(_warehouseRemoting, WarehouseCommon.WarehouseEndpoint);
                WarehouseLogger.LogMessage(Resources.RemotingInitialized, WarehouseCommon.WarehouseAddress);
                WarehouseLogger.LogMessage(Resources.MessagingInitialize, MessagingCommon.InitializeWarehouseQueue().QueueName);
                _serviceHost = new ServiceHost(typeof(WarehouseService));
                _serviceHost.Open();
                WarehouseLogger.LogMessage(Resources.MessagingRunning);
                Console.ReadKey(true);
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                WarehouseLogger.LogException(ex);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Red;
                WarehouseLogger.LogMessage(Resources.ExceptionCaught);
            }
        }
    }
}