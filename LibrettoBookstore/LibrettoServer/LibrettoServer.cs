using System;
using Libretto.Database;

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
        public BookIntegration Books
        {
            get;
        } = new BookIntegration(DatabaseContext);

        /// <summary>
        /// 
        /// </summary>
        public OrderIntegration Orders
        {
            get;
        } = new OrderIntegration(DatabaseContext);

        /// <summary>
        /// 
        /// </summary>
        public CustomerIntegration Customers
        {
            get;
        } = new CustomerIntegration(DatabaseContext);

        /// <summary>
        /// 
        /// </summary>
        public PurchaseIntegration Purchases
        {
            get;
        } = new PurchaseIntegration(DatabaseContext);

        /// <summary>
        /// 
        /// </summary>
        private static LibrettoServer _instance;

        /// <summary>
        /// 
        /// </summary>
        private static readonly LibrettoDatabase DatabaseContext = new LibrettoDatabase();

        /// <summary>
        /// 
        /// </summary>
        public static LibrettoServer Instance => _instance ?? (_instance = new LibrettoServer());

        /// <summary>
        /// 
        /// </summary>
        private static void Main()
        {
            try
            {
                foreach (var customerInformation in Instance.Customers.List())
                {
                    Console.WriteLine($@"Identifier | {customerInformation.Id}");
                    Console.WriteLine($@"Name       | {customerInformation.Name}");
                    Console.WriteLine($@"E-mail     | {customerInformation.Email}");
                    Console.WriteLine($@"Location   | {customerInformation.Location}");
                    Console.WriteLine(@"+========+==================+");
                }

                foreach (var bookInformation in Instance.Books.List())
                {
                    Console.WriteLine($@"Identifier | {bookInformation.Id}");
                    Console.WriteLine($@"Title      | {bookInformation.Title}");
                    Console.WriteLine($@"Price      | {bookInformation.Price}");
                    Console.WriteLine($@"Stock      | {bookInformation.Stock}");
                    Console.WriteLine(@"+========+==================+");
                }

                foreach (var transactioninformation in Instance.Purchases.List())
                {
                    Console.WriteLine($@"Identifier | {transactioninformation.Key}");
                    Console.WriteLine($@"Title      | {transactioninformation.Value.BookTitle}");
                    Console.WriteLine($@"Price      | {transactioninformation.Value.CustomerName}");
                    Console.WriteLine($@"Stock      | {transactioninformation.Value.Timestamp:F}");
                    Console.WriteLine(@"+========+==================+");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey(true);
        }
    }
}