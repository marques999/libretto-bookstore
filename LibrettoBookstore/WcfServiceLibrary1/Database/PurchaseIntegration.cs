using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;

namespace Libretto.Database
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
            return _context.Purchases.FirstOrDefault(transactionInformation => transactionInformation.Id == transactionIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, Purchase> List()
        {
            return _context.Purchases.ToDictionary(transactionInformation => transactionInformation.Id, transactionInformation => transactionInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformatioon"></param>
        /// <returns></returns>
        public bool Insert(Purchase purchaseInformatioon)
        {
            try
            {
                _context.Purchases.Add(purchaseInformatioon);
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
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public bool Delete(Guid transactionIdentifier)
        {
            var sqlEntity = _context.Purchases.SingleOrDefault(purchaseInformation => purchaseInformation.Id == transactionIdentifier);

            if (sqlEntity == null)
            {
                return false;
            }

            try
            {
                _context.Purchases.Remove(sqlEntity);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}