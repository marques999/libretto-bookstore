using System;
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
            try
            {
                return _context.Orders.Count();
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
            try
            {
                return _context.Orders.ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Order> List(Guid id)
        {
            try
            {
                return _context.Orders.Where(elem => elem.CustomerId == id).ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        /// <returns></returns>
        public Response Insert(Order transactionInformation)
        {
            try
            {
                _context.Orders.Add(transactionInformation);
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
        /// <param name="transactionTimestamp"></param>
        /// <param name="transactionStatus"></param>
        /// <returns></returns>
        public Response UpdateStatus(Guid transactionIdentifier, DateTime transactionTimestamp, Status transactionStatus)
        {
            var sqlEntity = _context.Orders.SingleOrDefault(previousTransaction => previousTransaction.Id == transactionIdentifier);

            if (sqlEntity == null)
            {
                return Response.NotFound;
            }

            sqlEntity.Status = transactionStatus;
            sqlEntity.StatusTimestamp = transactionTimestamp;

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
        /// <param name="orderInformation"></param>
        /// <param name="hasPermissions"></param>
        /// <returns></returns>
        public Response Update(Order orderInformation, bool hasPermissions)
        {
            var sqlEntity = _context.Orders.SingleOrDefault(previousOrder => previousOrder.Id == orderInformation.Id);

            if (sqlEntity == null)
            {
                return Response.NotFound;
            }

            if (!hasPermissions && sqlEntity.Status != Status.Processing)
            {
                return Response.PermissionDenied;
            }

            sqlEntity.Total = orderInformation.Total;
            sqlEntity.Quantity = orderInformation.Quantity;

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
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Response DeleteOrder(Guid orderIdentifier)
        {
            var sqlEntity = _context.Orders.SingleOrDefault(orderInformation => orderInformation.Id == orderIdentifier);

            if (sqlEntity == null)
            {
                return Response.NotFound;
            }

            try
            {
                _context.Orders.Remove(sqlEntity);
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