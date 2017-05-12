﻿using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;

namespace LibrettoWCF.Database
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
            try
            {
                return _context.Orders.SingleOrDefault(transactionInformation => transactionInformation.Id == transactionIdentifier);
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
        public List<Order> List()
        {
            return _context.Orders.ToList();
        }

        public List<Order> List(Guid id)
        {
            return _context.Orders.Where(elem => elem.CustomerId == id).ToList();
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
        public List<Order> DispatchOrder(Guid transactionIdentifier, DateTime transactionTimestamp)
        {
            return UpdateStatus(transactionIdentifier, Status.WaitingDispatch, transactionTimestamp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionTimestamp"></param>
        public List<Order> ExecuteOrder(Guid transactionIdentifier, DateTime transactionTimestamp)
        {
            return UpdateStatus(transactionIdentifier, Status.DispatchComplete, transactionTimestamp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        public List<Order> CancelOrder(Guid transactionIdentifier, DateTime transactionTimestamp)
        {
            return UpdateStatus(transactionIdentifier, Status.OrderCancelled, transactionTimestamp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionStatus"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        private List<Order> UpdateStatus(Guid transactionIdentifier, Status transactionStatus, DateTime transactionTimestamp)
        {
            var sqlEntity = _context.Orders.SingleOrDefault(previousTransaction => previousTransaction.Id == transactionIdentifier);

            if (sqlEntity == null)
            {
                return null;
            }
            try
            {
                sqlEntity.Status = transactionStatus;
                sqlEntity.StatusTimestamp = transactionTimestamp;
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return _context.Orders.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public List<Order> Update(Order orderInformation)
        {
            var sqlEntity = _context.Orders.SingleOrDefault(previousOrder => previousOrder.Id == orderInformation.Id);

            if (sqlEntity == null)
            {
                return null;
            }

            try
            {
                sqlEntity.Quantity = orderInformation.Quantity;
                sqlEntity.Timestamp = orderInformation.Timestamp;
                sqlEntity.Total = orderInformation.Total;
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return _context.Orders.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public List<Order> DeleteOrder(Guid orderIdentifier)
        {
            var sqlEntity = _context.Orders.SingleOrDefault(orderInformation => orderInformation.Id == orderIdentifier);

            if (sqlEntity == null)
            {
                return null;
            }

            try
            {
                _context.Orders.Remove(sqlEntity);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return _context.Orders.ToList();
        }
    }
}