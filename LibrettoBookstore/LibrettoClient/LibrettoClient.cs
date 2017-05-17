using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Libretto.Forms;
using Libretto.Model;
using Libretto.StoreService;
using System.ServiceModel;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal class LibrettoClient : IStoreServiceCallback
    {
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
        public void RefreshBooks()
        {
            Books = Proxy.ListBooks();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshTransactions()
        {
            Transactions.Clear();
            Transactions.AddRange(Proxy.ListOrders());
            Transactions.AddRange(Proxy.ListPurchases());
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
                RefreshTransactions();
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
            if (Proxy.State == CommunicationState.Opened)
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
        /// <param name="customerInformation"></param>
        public void OnRegisterCustomer(Customer customerInformation)
        {
            MessageBox.Show("OnRegisterCustomer()");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        public void OnRegisterTransaction(Transaction purchaseInformation)
        {
            System.Diagnostics.Debug.Print("OnRegisterTransaction()");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        public void OnUpdateTransaction(Transaction purchaseInformation)
        {
            System.Diagnostics.Debug.Print("OnUpdateTransaction()");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        public void OnDeleteTransaction(Guid transactionIdentifier)
        {
            System.Diagnostics.Debug.Print("OnDeleteTransaction()");
        }
    }
}