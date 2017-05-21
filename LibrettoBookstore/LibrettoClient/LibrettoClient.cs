using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;

using Libretto.Forms;
using Libretto.Model;
using Libretto.StoreService;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    [CallbackBehavior(UseSynchronizationContext = false)]
    internal class LibrettoClient : IStoreServiceCallback
    {
        /// <summary>
        /// 
        /// </summary>
        public static event Action OnRefresh;

        /// <summary>
        /// 
        /// </summary>
        private static LibrettoClient _instance;

        /// <summary>
        /// 
        /// </summary>
        public static LibrettoClient Instance => _instance ?? (_instance = new LibrettoClient());

        /// <summary>
        /// 
        /// </summary>
        private LibrettoClient()
        {
            Proxy = new StoreServiceClient(new InstanceContext(this));
        }

        /// <summary>
        /// 
        /// </summary>
        public Clerk Session
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public StoreServiceClient Proxy
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Book> Books
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Transaction> Transactions
        {
            get;
        } = new List<Transaction>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsAdministrator()
        {
            return Session?.Permissions == Permissions.Administrator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginForm"></param>
        /// <returns></returns>
        public bool Login(LoginTemplate loginForm)
        {
            if (Proxy.ClientCredentials == null)
            {
                return false;
            }

            try
            {
                Proxy.ClientCredentials.UserName.UserName = loginForm.Email;
                Proxy.ClientCredentials.UserName.Password = loginForm.Password;

                var clerkInformation = Proxy.Profile();

                if (clerkInformation != null)
                {
                    Session = clerkInformation;
                }
                else
                {
                    return false;
                }

                RefreshBooks();
                Transactions.Clear();
                Transactions.AddRange(Proxy.ListOrders());
                Transactions.AddRange(Proxy.ListPurchases());
                SubscribeNotifications();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshBooks()
        {
            Books = Proxy.ListBooks();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Logout()
        {
            Session = null;
            ResetProxy();
        }

        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetProxy()
        {
            if (Proxy.State == CommunicationState.Opened)
            {
                Proxy.Close();
            }

            Proxy = new StoreServiceClient(new InstanceContext(this));
        }

        /// <summary>
        /// 
        /// </summary>
        public void SubscribeNotifications()
        {
            if (Proxy.State != CommunicationState.Faulted)
            {
                Proxy.Subscribe();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void UnsubscribeNotifications()
        {
            if (Proxy.State == CommunicationState.Opened)
            {
                Proxy.Unsubscribe();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        public void OnDeleteTransaction(Guid transactionIdentifier)
        {
            if (Transactions.RemoveAll(transactionInformation => transactionInformation.Id == transactionIdentifier) > 0)
            {
                OnRefresh?.Invoke();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        public void OnUpdateTransaction(Transaction transactionInformation)
        {
            var transactionIndex = Transactions.FindIndex(previousTransaction => previousTransaction.Id == transactionInformation.Id);

            if (transactionIndex >= 0)
            {
                Transactions[transactionIndex] = transactionInformation;
            }
            else
            {
                Transactions.Add(transactionInformation);
            }

            OnRefresh?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        public void OnRegisterTransaction(Transaction transactionInformation)
        {
            var transactionIndex = Transactions.FindIndex(previousTransaction => previousTransaction.Id == transactionInformation.Id);

            if (transactionIndex >= 0)
            {
                Transactions[transactionIndex] = transactionInformation;
            }
            else
            {
                Transactions.Add(transactionInformation);
            }

            OnRefresh?.Invoke();
        }
    }
}