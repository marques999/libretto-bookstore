using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Messaging;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Xml.Serialization;

using Libretto.Messaging;
using Libretto.Model;
using Libretto.Properties;
using Libretto.Warehouse;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseServer : MarshalByRefObject, IWarehouseService, IMessageVisitor
    {
        /// <summary>
        /// 
        /// </summary>
        public event TransactionHandler OnRefresh;

        /// <summary>
        /// 
        /// </summary>
        private readonly WarehouseOrders _orders;

        /// <summary>
        /// 
        /// </summary>
        private readonly MessageQueue _warehouseQueue;

        /// <summary>
        /// 
        /// </summary>
        private readonly IRemotingService _bookstore;

        /// <summary>
        /// 
        /// </summary>
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(WarehouseOrders));

        /// <summary>
        /// 
        /// </summary>
        private WarehouseServer()
        {
            ChannelServices.RegisterChannel(new TcpChannel(new Hashtable
            {
                {"port", WarehouseCommon.WarehousePort}
            }, new BinaryClientFormatterSinkProvider(), new BinaryServerFormatterSinkProvider
            {
                TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
            }), false);

            LogMessage(Resources.RemotingRegisterService, nameof(IRemotingService));
            RemotingConfiguration.RegisterActivatedServiceType(typeof(IRemotingService));
            LogMessage(Resources.RemotingRegisterService, nameof(IWarehouseService));
            RemotingConfiguration.RegisterActivatedServiceType(typeof(WarehouseServer));
            LogMessage(Resources.RemotingMarshalService, nameof(WarehouseServer));
            RemotingServices.Marshal(this, WarehouseCommon.WarehouseEndpoint);
            LogMessage(Resources.RemotingInitialized, WarehouseCommon.WarehouseAddress);
            LogMessage(Resources.RemotingEstablish, nameof(IRemotingService), WarehouseCommon.BookstoreAddress);
            _bookstore = (IRemotingService)RemotingServices.Connect(typeof(IRemotingService), WarehouseCommon.BookstoreAddress);
            LogMessage(Resources.RemotingInitialized, nameof(IRemotingService));
            _warehouseQueue = MessagingCommon.InitializeWarehouseQueue();
            LogMessage(Resources.MessagingInitialize, _warehouseQueue.Path);
            _warehouseQueue.ReceiveCompleted += OnReceive;
            _warehouseQueue.BeginReceive(MessagingCommon.MsmqTimeout);
            LogMessage(Resources.MessagingRunning);

            if (File.Exists(WarehouseCommon.TransactionsFilename))
            {
                LogMessage(Resources.SerializationRead, WarehouseCommon.TransactionsFilename);

                using (var reader = new FileStream(WarehouseCommon.TransactionsFilename, FileMode.Open))
                {
                    _orders = (WarehouseOrders)_serializer.Deserialize(reader) ?? new WarehouseOrders();
                }

                LogMessage(Resources.SerializationDone, _orders.Orders.Count, nameof(WarehouseOrders));
            }
            else
            {
                _orders = new WarehouseOrders();
                _orders.Serialize(_serializer, WarehouseCommon.TransactionsFilename);
                LogMessage(Resources.SerializationWrite, WarehouseCommon.TransactionsFilename);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="receiveCompleted"></param>
        private void OnReceive(object src, ReceiveCompletedEventArgs receiveCompleted)
        {
            try
            {
                (_warehouseQueue.EndReceive(receiveCompleted.AsyncResult)?.Body as IMessage)?.Process(this);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            _warehouseQueue.BeginReceive(MessagingCommon.MsmqTimeout);
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
        public void SerializeTransactions()
        {
            LogMessage(Resources.SerializationWrite, WarehouseCommon.TransactionsFilename);
            _orders.Serialize(_serializer, WarehouseCommon.TransactionsFilename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseOrder"></param>
        public void InsertOrder(WarehouseOrder warehouseOrder)
        {
            try
            {
                LogMessage(Resources.MessagingInsertOrder, warehouseOrder.Identifier, warehouseOrder.Title, warehouseOrder.DateCreated);
                warehouseOrder.Status = WarehouseStatus.Pending;
                _orders.Insert(warehouseOrder);
                OnRefresh?.Invoke(_orders.Orders);
                SerializeTransactions();
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageUpdate"></param>
        public void UpdateOrder(MessageUpdate messageUpdate)
        {
            try
            {
                LogMessage(Resources.MessagingUpdateOrder, messageUpdate.Identifier, messageUpdate.Quantity, messageUpdate.Total);

                if (_orders.Update(messageUpdate.Identifier, messageUpdate.Quantity, messageUpdate.Total) == false)
                {
                    return;
                }

                OnRefresh?.Invoke(_orders.Orders);
                SerializeTransactions();
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageCancel"></param>
        public void CancelOrder(MessageCancel messageCancel)
        {
            try
            {
                LogMessage(Resources.MessagingCancelOrder, messageCancel.Identifier, messageCancel.Timestamp);

                if (_orders.Cancel(messageCancel.Identifier, messageCancel.Timestamp) == false)
                {
                    return;
                }

                SerializeTransactions();
                OnRefresh?.Invoke(_orders.Orders);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<WarehouseOrder> ListOrders()
        {
            return _orders.Orders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public bool DispatchOrder(Guid transactionIdentifier)
        {
            try
            {
                var transactionTimestamp = DateTime.Now;

                LogMessage(Resources.RemotingDispatchOrder, transactionIdentifier, transactionTimestamp);

                if (_bookstore.DispatchOrder(transactionIdentifier) != Response.Success)
                {
                    return false;
                }

                if (_orders.Dispatch(transactionIdentifier, transactionTimestamp) == false)
                {
                    return false;
                }

                SerializeTransactions();
                OnRefresh?.Invoke(_orders.Orders);

                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Main()
        {
            Console.CursorVisible = false;
            Console.Title = Resources.WindowTitle;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine(Resources.Header);

            try
            {
                new WarehouseServer();
            }
            catch (Exception ex)
            {
                LogException(ex);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Red;
                LogMessage(Resources.ExceptionCaught);
            }

            Console.ReadKey(true);
        }
    }
}