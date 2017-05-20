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
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public Response DispatchOrder(Guid transactionIdentifier)
        {
            return LibrettoDatabase.OrderIntegration.Update(transactionIdentifier, Status.Processing, DateTime.Now.AddDays(2));
        }
    }
}