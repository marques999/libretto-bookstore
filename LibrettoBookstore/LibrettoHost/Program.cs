using System;
using System.Linq;
using System.ServiceModel;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    public class LibrettoHost
    {
        /// <summary>
        /// 
        /// </summary>
        private static ServiceHost _webstore;

        /// <summary>
        /// 
        /// </summary>
        private static ServiceHost _bookstore;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            _bookstore = new ServiceHost(typeof(BookstoreService.StoreServiceClient));
            _webstore = new ServiceHost(typeof(WebstoreService.WebstoreServiceClient));
            _bookstore.Open();
            Console.WriteLine($@"IStoreService ready and running on port {_bookstore.BaseAddresses.FirstOrDefault()?.Port}...");
            _webstore.Open();
            Console.WriteLine($@"IWebstoreService ready and running on port {_webstore.BaseAddresses.FirstOrDefault()?.Port}...");
            Console.WriteLine("Press any key to close.");
            Console.ReadKey(true);
            _bookstore.Close();
            _webstore.Close();
        }
    }
}