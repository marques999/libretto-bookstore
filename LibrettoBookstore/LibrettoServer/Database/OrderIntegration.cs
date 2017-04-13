using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;

namespace Libretto.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal class OrderIntegration
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly LibrettoDatabase _context;

        /// <summary>
        ///
        /// </summary>
        public OrderIntegration(LibrettoDatabase sqlContext)
        {
            _context = sqlContext;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count()
        {
            return _context.Orders.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public Order Lookup(Guid transactionIdentifier)
        {
            return _context.Orders.FirstOrDefault(transactionInformation => transactionInformation.Id == transactionIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, Order> List()
        {
            return _context.Orders.ToDictionary(transactionInformation => transactionInformation.Id, transactionInformation => transactionInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        /// <returns></returns>
        public bool Insert(Order transactionInformation)
        {
            try
            {
                _context.Orders.Add(transactionInformation);
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
        /// <param name="transactionTimestamp"></param>
        public bool DispatchOrder(Guid transactionIdentifier, DateTime transactionTimestamp)
        {
            return Update(transactionIdentifier, Status.WaitingDispatch, transactionTimestamp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionTimestamp"></param>
        public bool ExecuteOrder(Guid transactionIdentifier, DateTime transactionTimestamp)
        {
            return Update(transactionIdentifier, Status.DispatchComplete, transactionTimestamp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        public bool CancelOrder(Guid transactionIdentifier, DateTime transactionTimestamp)
        {
            return Update(transactionIdentifier, Status.OrderCancelled, transactionTimestamp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionStatus"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        private bool Update(Guid transactionIdentifier, Status transactionStatus, DateTime transactionTimestamp)
        {
            var sqlEntity = _context.Orders.SingleOrDefault(previousTransaction => previousTransaction.Id == transactionIdentifier);

            if (sqlEntity == null)
            {
                return false;
            }
            try
            {
                sqlEntity.Status = transactionStatus;
                sqlEntity.StatusTimestamp = transactionTimestamp;
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