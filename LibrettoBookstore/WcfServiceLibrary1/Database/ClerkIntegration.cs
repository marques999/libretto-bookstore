using System.Linq;
using System.Security.Principal;

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
        /// <param name="clerkEmail"></param>
        /// <returns></returns>
        public Clerk Lookup(string clerkEmail)
        {
            try
            {
                return string.IsNullOrEmpty(clerkEmail) ? null : _context.Clerks.SingleOrDefault(clerkInformation => clerkInformation.Email == clerkEmail);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clerkIdentity"></param>
        /// <returns></returns>
        public Clerk Lookup(IIdentity clerkIdentity)
        {
            return clerkIdentity == null ? null : Lookup(clerkIdentity.Name);
        }
    }
}