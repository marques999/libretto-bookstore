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
            return _context.Purchases.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public Purchase Lookup(Guid transactionIdentifier)
        {
            return _context.Purchases.SingleOrDefault(transactionInformation => transactionInformation.Id == transactionIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Purchase> List()
        {
            return _context.Purchases.ToList();
        }

        /*public Dictionary<Guid, Purchase> List()
        {
            return _context.Purchases.ToDictionary(transactionInformation => transactionInformation.Id, transactionInformation => transactionInformation);
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> Insert(Purchase purchaseInformation)
        {
            try
            {
                _context.Purchases.Add(purchaseInformation);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return _context.Purchases.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> Update(Purchase purchaseInformation)
        {
            var sqlEntity = _context.Purchases.SingleOrDefault(previousPurchase => previousPurchase.Id == purchaseInformation.Id);

            if (sqlEntity == null)
            {
                return null;
            }

            try
            {
                sqlEntity.Quantity = purchaseInformation.Quantity;
                sqlEntity.Timestamp = purchaseInformation.Timestamp;
                sqlEntity.Total = purchaseInformation.Total;
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return _context.Purchases.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public List<Purchase> Delete(Guid transactionIdentifier)
        {
            var sqlEntity = _context.Purchases.SingleOrDefault(purchaseInformation => purchaseInformation.Id == transactionIdentifier);

            if (sqlEntity == null)
            {
                return null;
            }

            try
            {
                _context.Purchases.Remove(sqlEntity);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return _context.Purchases.ToList();
        }
    }
}