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
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WebstoreService)))
            {
                Console.WriteLine("StockService ready. Press any key to close.");
                Console.WriteLine("Running on port " + host.BaseAddresses.FirstOrDefault()?.Port);
                Console.ReadKey(true);
            }
        }
    }
}