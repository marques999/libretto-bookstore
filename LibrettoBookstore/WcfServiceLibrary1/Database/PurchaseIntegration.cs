using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;

namespace LibrettoWCF.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal class PurchaseIntegration
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly LibrettoDatabase _context;

        /// <summary>
        ///
        /// </summary>
        public PurchaseIntegration(LibrettoDatabase librettoDatabase)
        {
            _context = librettoDatabase;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public Purchase Lookup(Guid transactionIdentifier)
        {
            try
            {
                return _context.Purchases.SingleOrDefault(transactionInformation => transactionInformation.Id == transactionIdentifier);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Purchase> List()
        {
            try
            {
                return _context.Purchases.ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public List<Purchase> List(Guid transactionIdentifier)
        {
            return _context.Purchases.Where(purchaseInformation => purchaseInformation.CustomerId == transactionIdentifier).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public Response Insert(Purchase purchaseInformation)
        {
            try
            {
                purchaseInformation.Timestamp = DateTime.Now;
                _context.Purchases.Add(purchaseInformation);
                _context.SaveChanges();
                LibrettoHost.InvoiceQueue.Send(Invoice.FromPurchase(purchaseInformation));
            }
            catch
            {
                return Response.DatabaseError;
            }

            return LibrettoDatabase.BookIntegration.UpdateStock(purchaseInformation.BookId, purchaseInformation.Quantity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public Response Update(Purchase purchaseInformation)
        {
            return Response.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public Response Delete(Guid transactionIdentifier)
        {
            try
            {
                var sqlEntity = _context.Purchases.SingleOrDefault(purchaseInformation => purchaseInformation.Id == transactionIdentifier);

                if (sqlEntity == null)
                {
                    return Response.NotFound;
                }

                _context.Purchases.Remove(sqlEntity);
                _context.SaveChanges();
            }
            catch
            {
                return Response.DatabaseError;
            }

            return Response.Success;
        }
    }
}