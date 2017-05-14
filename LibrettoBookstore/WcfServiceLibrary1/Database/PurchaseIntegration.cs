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
        public int Count()
        {
            try
            {
                return _context.Purchases.Count();
            }
            catch
            {
                return 0;
            }
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

        public List<Purchase> List(Guid id)
        {
            return _context.Purchases.Where(elem => elem.CustomerId == id).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public bool Insert(Purchase purchaseInformation)
        {
            try
            {
                _context.Purchases.Add(purchaseInformation);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public Response Update(Purchase purchaseInformation)
        {
            var sqlEntity = _context.Purchases.SingleOrDefault(previousPurchase => previousPurchase.Id == purchaseInformation.Id);

            if (sqlEntity == null)
            {
                return Response.NotFound;
            }

            sqlEntity.Total = purchaseInformation.Total;
            sqlEntity.Quantity = purchaseInformation.Quantity;

            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return Response.DatabaseError;
            }

            return Response.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public Response Delete(Guid transactionIdentifier)
        {
            var sqlEntity = _context.Purchases.SingleOrDefault(purchaseInformation => purchaseInformation.Id == transactionIdentifier);

            if (sqlEntity == null)
            {
                return Response.NotFound;
            }

            try
            {
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