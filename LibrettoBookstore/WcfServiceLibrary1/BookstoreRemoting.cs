using System;

using Libretto.Model;
using Libretto.Warehouse;

using LibrettoWCF.Database;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    public class BookstoreRemoting : MarshalByRefObject, IBookstoreRemoting
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Response DispatchOrder(Guid orderIdentifier)
        {
            return LibrettoDatabase.OrderIntegration.Satisfy(orderIdentifier);
        }
    }
}