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
        /// <summary>
        /// 
        /// </summary>
        private LibrettoClient()
        {
            Customers.Add(new Customer
            {
                Identifier = Guid.NewGuid(),
                Name = "Allison Turner",
                Email = "allison.t@yahoo.com",
                Location = "Valongo, Portugal"
            });

            Customers.Add(new Customer
            {
                Identifier = Guid.NewGuid(),
                Name = "Matthew Perry",
                Email = "matt_perry@hotmail.com",
                Location = "Chaves, Portugal"
            });

            Customers.Add(new Customer
            {
                Identifier = Guid.NewGuid(),
                Name = "Randy White",
                Email = "randy@gmail.com",
                Location = "Lisboa, Portugal"
            });

            Customers.Add(new Customer
            {
                Identifier = Guid.NewGuid(),
                Name = "Heather Davis",
                Email = "hdavis@aol.com",
                Location = "Trancoso, Portugal"
            });

            Customers.Add(new Customer
            {
                Identifier = Guid.NewGuid(),
                Name = "Steven Mitchell",
                Email = "steven.xxx@outlook.com",
                Location = "Penafiel, Portugal"
            });

            for (var i = 0; i < 10; i++)
            {
                GenerateBook(i, Guid.NewGuid());
            }

            for (var i = 0; i < 10; i++)
            {
                GenerateOrder(Guid.NewGuid());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIndex"></param>
        /// <param name="bookIdentifier"></param>
        private void GenerateBook(int bookIndex, Guid bookIdentifier)
        {
            Books.Add(new Book
            {
                Identifier = bookIdentifier,
                Price = _randomGenerator.NextDouble() * 200,
                Stock = _randomGenerator.Next(100),
                Title = $"Dummy Book {(char)('A' + bookIndex)}"
            });
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
        /// <param name="orderIdentifier"></param>
        private void GenerateOrder(Guid orderIdentifier)
        {
            var randomBook = Books[_randomGenerator.Next(Books.Count)];
            var randomCustomer = Customers[_randomGenerator.Next(Customers.Count)];

            Transactions.Add(new Order
            {
                Identifier = orderIdentifier,
                CustomerId = randomCustomer.Identifier,
                CustomerName = randomCustomer.Name,
                BookId = randomBook.Identifier,
                BookName = randomBook.Title,
                Quantity = 1,
                Timestamp = RandomTimestamp(new DateTime(2017, 3, 1), new DateTime(2017, 5, 1))
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Book> Books
        {
            get;
        } = new List<Book>();

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
        public List<Customer> Customers
        {
            get;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}