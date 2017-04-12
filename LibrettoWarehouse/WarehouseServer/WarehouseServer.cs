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
using Libretto.Warehouse;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseServer : MarshalByRefObject, WarehouseInterface, IMessageVisitor
    {
        /// <summary>
        /// 
        /// </summary>
        private WarehouseServer()
        {
            InitializeMsmq();
            InitializeDatabase();
            InitializeRemoting();
        }

        /// <summary>
        /// 
        /// </summary>
        public MessageQueue WarehouseQueue
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        private XmlSerializer BookSerializer
        {
            get;
        } = new XmlSerializer(typeof(WarehouseBooks));

        /// <summary>
        /// 
        /// </summary>
        private XmlSerializer TransactionSerializer
        {
            get;
        } = new XmlSerializer(typeof(WarehouseOrders));

        /// <summary>
        /// 
        /// </summary>
        private WarehouseBooks _books;

        /// <summary>
        /// 
        /// </summary>
        private WarehouseOrders _orders;

        /// <summary>
        /// 
        /// </summary>
        public event RefreshHandler OnRefreshBooks;

        /// <summary>
        /// 
        /// </summary>
        public event RefreshHandler OnRefreshOrders;

        /// <summary>
        /// 
        /// </summary>
        private static WarehouseServer _instance;

        /// <summary>
        /// 
        /// </summary>
        public static WarehouseServer Instance => _instance ?? (_instance = new WarehouseServer());

        /// <summary>
        /// 
        /// </summary>
        private void InitializeMsmq()
        {
            try
            {
                WarehouseQueue = LibrettoCommon.InitializeQueue();
                LogMessage($"Messaging: Initializing private queue ({WarehouseQueue.Path})...");
                WarehouseQueue.ReceiveCompleted += OnReceive;
                WarehouseQueue.BeginReceive(TimeSpan.FromMinutes(5));
                LogMessage("Messaging: Service running and receiving messages asynchronously.");
            }
            catch (Exception ex)
            {
                LogMessage($"{ex.Source}: {ex.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeDatabase()
        {
            try
            {
                LogMessage($"XmlSerializer: Reading {WarehouseCommon.BooksFilename}...");
                _books = InitializeDatabase<WarehouseBooks>(BookSerializer, WarehouseCommon.BooksFilename);
                LogMessage($"XmlSerializer: Success! Found {_books.Books.Count} records for \"WarehouseBooks\".");
                LogMessage($"XmlSerializer: Reading {WarehouseCommon.TransactionsFilename}...");
                _orders = InitializeDatabase<WarehouseOrders>(TransactionSerializer, WarehouseCommon.TransactionsFilename);
                LogMessage($"XmlSerializer: Success! Found {_orders.Orders.Count} records for \"WarehouseOrders\".");
            }
            catch (Exception ex)
            {
                LogMessage($"{ex.Source}: {ex.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeRemoting()
        {
            var tcpChannel = new TcpChannel(new Hashtable
            {
                {"port", WarehouseCommon.RemotingPort}
            }, new BinaryClientFormatterSinkProvider(), new BinaryServerFormatterSinkProvider()
            {
                TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
            });

            ChannelServices.RegisterChannel(tcpChannel, false);

            var localHost = new Address((ushort)new Uri(((ChannelDataStore)tcpChannel.ChannelData).ChannelUris[0]).Port);

            LogMessage("Remoting: Registering activated service \"IWarehouseService\"...");
            RemotingConfiguration.RegisterActivatedServiceType(typeof(WarehouseServer));
            LogMessage("Remoting: Marshalling \"WarehouseServer\" singleton object...");
            RemotingServices.Marshal(this, WarehouseCommon.RemotingEndpoint);
            LogMessage($"Remoting: IWarehouseService [tcp://{localHost.Host}:{localHost.Port}/{WarehouseCommon.RemotingEndpoint}]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="receiveCompleted"></param>
        private void OnReceive(object src, ReceiveCompletedEventArgs receiveCompleted)
        {
            LogMessage("Remoting: Registering activated service \"IWarehouseService\"...");
            (WarehouseQueue.EndReceive(receiveCompleted.AsyncResult)?.Body as IMessageSubject)?.Process(this);
            WarehouseQueue.BeginReceive();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverMessage"></param>
        private static void LogMessage(string serverMessage)
        {
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] {serverMessage}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlSerializer"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static T InitializeDatabase<T>(XmlSerializer xmlSerializer, string fileName) where T : SerializableClass, new()
        {
            var unserializedInformaton = new T();

            if (File.Exists(fileName))
            {
                using (var reader = new FileStream(fileName, FileMode.Open))
                {
                    unserializedInformaton = (T)xmlSerializer.Deserialize(reader) ?? new T();
                }
            }
            else
            {
                unserializedInformaton.Serialize(xmlSerializer, fileName);
            }

            return unserializedInformaton;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SerializeBooks()
        {
            LogMessage($"XmlSerializer: Writing {WarehouseCommon.BooksFilename}...");
            _books.Serialize(BookSerializer, WarehouseCommon.BooksFilename);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SerializeTransactions()
        {
            LogMessage($"XmlSerializer: Writing {WarehouseCommon.TransactionsFilename}...");
            _orders.Serialize(TransactionSerializer, WarehouseCommon.TransactionsFilename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        public void InsertOrder(Order transactionInformation)
        {
            LogMessage($"Messaging: UpdateOrder(\n\t\"{transactionInformation.Identifier}\", \n\t\"{transactionInformation.BookName}\", \n\t\"{transactionInformation.Timestamp}\")");
            _orders.Insert(transactionInformation);
            OnRefreshOrders?.Invoke();
            SerializeTransactions();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageCancel"></param>
        public void CancelOrder(MessageCancel messageCancel)
        {
            LogMessage($"Messaging: CancelOrder(\"{messageCancel.Identifier}\")");

            if (_orders.Delete(messageCancel.Identifier) == false)
            {
                return;
            }

            SerializeTransactions();
            OnRefreshOrders?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageUpdate"></param>
        public void UpdateOrder(MessageUpdate messageUpdate)
        {
            LogMessage($"Messaging: UpdateOrder(\"{messageUpdate.Identifier}\", \"{messageUpdate.Status}\", \"{messageUpdate.Timestamp}\")");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> ListOrders()
        {
            return _orders.Orders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, Book> ListBooks()
        {
            return _books.Books;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionStatus"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        public bool UpdateOrder(Guid transactionIdentifier, Status transactionStatus, DateTime transactionTimestamp)
        {
            LogMessage($"Remoting: UpdateOrder(\"{transactionIdentifier}\", \"{transactionStatus}\", \"{transactionTimestamp}\")");

            var operationResult = _orders.Update(transactionIdentifier, transactionStatus, transactionTimestamp);

            if (operationResult)
            {
                SerializeTransactions();
            }

            WarehouseQueue.Send(new MessageUpdate
            {
                Identifier = transactionIdentifier,
                Status = transactionStatus,
                Timestamp = transactionTimestamp
            });

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <param name="bookQuantity"></param>
        /// <returns></returns>
        public bool UpdateStock(Guid bookIdentifier, int bookQuantity)
        {
            LogMessage($"Remoting: UpdateStock(\"{bookIdentifier}\", \"{bookQuantity}\")");

            var operationResult = _books.UpdateStock(bookIdentifier, bookQuantity);

            if (operationResult)
            {
                SerializeBooks();
            }

            return operationResult;
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
            Console.Title = "Libretto Warehouse";
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine(@"
 _ _ _              _   _        
| (_) |__  _ __ ___| |_| |_ ___  
| | | '_ \| '__/ _ \ __| __/ _ \ 
| | | |_) | | |  __/ |_| || (_) | Warehouse
|_|_|_.__/|_|  \___|\__|\__\___/  [SERVER]
");
            Instance.Equals(true);
            Console.ReadLine();
        }
    }
}