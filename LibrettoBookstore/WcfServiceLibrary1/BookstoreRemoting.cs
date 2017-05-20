using System;

using Libretto.Model;
using Libretto.Warehouse;

using LibrettoWCF.Database;
using LibrettoWCF.Tools;

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
            try
            {
                Console.WriteLine(transactionIdentifier);

                var operationResult = LibrettoDatabase.OrderIntegration.UpdateStatus(transactionIdentifier, Status.Processing);

                if (operationResult != Response.Success)
                {
                    return operationResult;
                }

                var order = LibrettoDatabase.OrderIntegration.Lookup(transactionIdentifier);

                if (order == null)
                {
                    return Response.NotFound;
                }

                operationResult = LibrettoDatabase.BookIntegration.UpdateStock(order.BookId, -10);

                return operationResult == Response.Success ? EmailClient.Instance.NotifyUpdate(LibrettoDatabase.OrderIntegration.Lookup(transactionIdentifier)) : operationResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Response.DatabaseError;
        }
    }
}