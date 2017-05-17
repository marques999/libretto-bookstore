using System.Linq;

using Libretto.Model;

namespace LibrettoWCF.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal class ClerkIntegration
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly LibrettoDatabase _context;

        /// <summary>
        ///
        /// </summary>
        public ClerkIntegration(LibrettoDatabase sqlContext)
        {
            _context = sqlContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerEmail"></param>
        /// <returns></returns>
        public Clerk Lookup(string customerEmail)
        {
            try
            {
                return _context.Clerks.SingleOrDefault(customerInformation => customerInformation.Email == customerEmail);
            }
            catch
            {
                return null;
            }
        }
    }
}