﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Libretto.BookstoreService;
using Libretto.Forms;
using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal class LibrettoClient
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
            Proxy = new StoreServiceClient();
            RefreshBooks();
            RefreshCustomers();
            RefreshTransactions();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshBooks()
        {
            Books = Proxy.GetBooksList();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshCustomers()
        {
            Customers = Proxy.GetCustomersList();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshTransactions()
        {
            Transactions.Clear();
            Transactions.AddRange(Proxy.GetOrdersList());
            Transactions.AddRange(Proxy.GetPurchasesList());
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
        public List<Customer> Customers
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
        /// <param name="clerkInformation"></param>
        public void Login(Clerk clerkInformation)
        {
            Session = clerkInformation;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Logout()
        {
            Session = null;
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
    }
}