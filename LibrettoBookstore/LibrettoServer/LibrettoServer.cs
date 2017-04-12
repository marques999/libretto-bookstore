using System;
using System.Data.SqlClient;

using Libretto.Integration;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal class LibrettoServer
    {
        /// <summary>
        /// 
        /// </summary>
        private LibrettoServer()
        {
            _sqlConnection.Open();
            BookIntegration = new BookIntegration(_sqlConnection);
            CustomerIntegration = new CustomerIntegration(_sqlConnection);
            TransactionIntegration = new TransactionIntegration(_sqlConnection);
        }

        /// <summary>
        /// 
        /// </summary>
        public BookIntegration BookIntegration
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public CustomerIntegration CustomerIntegration
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public TransactionIntegration TransactionIntegration
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        private static LibrettoServer _instance;

        /// <summary>
        /// 
        /// </summary>
        public static LibrettoServer Instance => _instance ?? (_instance = new LibrettoServer());

        /// <summary>
        /// 
        /// </summary>
        private readonly SqlConnection _sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;" +
            $"AttachDbFilename={AppDomain.CurrentDomain.BaseDirectory}LibrettoDatabase.mdf;" +
            "Integrated Security=True;Connect Timeout=5");

        /// <summary>
        /// 
        /// </summary>
        private static void Main()
        {
            try
            {
                var customerList = Instance.CustomerIntegration.Customers;

                foreach (var customerInformation in customerList)
                {
                    Console.WriteLine($@"Name       | {customerInformation.Value.Name}");
                    Console.WriteLine($@"E-mail     | {customerInformation.Value.Email}");
                    Console.WriteLine($@"Location   | {customerInformation.Value.Location}");
                    Console.WriteLine($@"Identifier | {customerInformation.Value.Identifier}");
                    Console.WriteLine(@"+========+==================+");
                }

                var itemList = Instance.BookIntegration.Books;

                foreach (var bookInformation in itemList)
                {
                    Console.WriteLine($@"Title      | {bookInformation.Value.Title}");
                    Console.WriteLine($@"Price      | {bookInformation.Value.Price}");
                    Console.WriteLine($@"Stock      | {bookInformation.Value.Stock}");
                    Console.WriteLine($@"Identifier | {bookInformation.Value.Identifier}");
                    Console.WriteLine(@"+========+==================+");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}