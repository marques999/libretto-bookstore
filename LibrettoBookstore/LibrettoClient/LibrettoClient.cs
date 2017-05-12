using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Libretto.Forms;
using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal class LibrettoClient
    {

        private static StoreService.StoreServiceClient proxy;

        private LibrettoClient()
        {
            /*Customers = proxy.GetCustomersList();
            Books = proxy.GetBooksList();
            Orders = proxy.GetOrdersList();
            Purchases = proxy.GetPurchasesList();*/
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DateTime RandomTimestamp(DateTime start, DateTime end)
        {
            return start + new TimeSpan(0, _randomGenerator.Next(0, (int)(end - start).TotalMinutes), 0);
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly Random _randomGenerator = new Random();


        /// <summary>
        /// 
        /// </summary>
        public List<Book> Books
        {
            get;
        } = new List<Book>();

        public List<Purchase> Purchases
        {
            get;
        } = new List<Purchase>();

        public List<Order> Orders
        {
            get;
        } = new List<Order>();

        /// <summary>
        /// 
        /// </summary>
        public List<Customer> Customers
        {
            get;
            set;
        } = new List<Customer>();

        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Permissions Permissions
        {
            get;
            private set;
        } = Permissions.None;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        public void Login(string userEmail)
        {
            Email = userEmail;
            Permissions = Permissions.Administrator;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Logout()
        {
            Email = null;
            Permissions = Permissions.None;
        }

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
        [STAThread]
        private static void Main()
        {
            proxy = new StoreService.StoreServiceClient();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}