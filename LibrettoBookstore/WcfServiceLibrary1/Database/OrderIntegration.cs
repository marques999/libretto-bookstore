using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;
using Libretto.Warehouse;

using LibrettoWCF.Tools;

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
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public List<Order> List(Guid transactionIdentifier)
        {
            try
            {
                return _context.Orders.Where(orderInformation => orderInformation.CustomerId == transactionIdentifier).ToList();
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
                var bookInformation = LibrettoDatabase.BookIntegration.Lookup(transactionInformation.BookId);

                if (bookInformation == null)
                {
                    return Response.NotFound;
                }

                transactionInformation.Timestamp = DateTime.Now;

                if (transactionInformation.Quantity > bookInformation.Stock)
                {
                    transactionInformation.Status = Status.Waiting;
                    transactionInformation.StatusTimestamp = transactionInformation.Timestamp;
                }
                else
                {
                    transactionInformation.Status = Status.Dispatched;
                    transactionInformation.StatusTimestamp = DateTime.Now.AddDays(1);
                }

                _context.Orders.Add(transactionInformation);
                _context.SaveChanges();

                if (transactionInformation.Status == Status.Waiting)
                {
                    LibrettoHost.WarehouseService.InsertOrder(WarehouseOrder.FromOrder(transactionInformation));
                }
                else
                {
                    LibrettoDatabase.BookIntegration.UpdateStock(transactionInformation.BookId, transactionInformation.Quantity);
                }

                return EmailClient.Instance.NotifyInsert(transactionInformation);
            }
            catch
            {
                return Response.DatabaseError;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public Response Cancel(Guid transactionIdentifier)
        {
            try
            {
                var sqlEntity = _context.Orders.SingleOrDefault(previousTransaction => previousTransaction.Id == transactionIdentifier);

                if (sqlEntity == null)
                {
                    return Response.NotFound;
                }

                if (sqlEntity.Status == Status.Cancelled)
                {
                    return Response.BadRequest;
                }

                var currentTimestamp = DateTime.Now;
                var deleteOrder = sqlEntity.Status == Status.Waiting;
                var dayStart = sqlEntity.StatusTimestamp.AddHours(-sqlEntity.StatusTimestamp.Hour);

                if (sqlEntity.Status != Status.Waiting && currentTimestamp >= dayStart)
                {
                    return Response.BadRequest;
                }

                sqlEntity.Status = Status.Cancelled;
                sqlEntity.StatusTimestamp = DateTime.Now;
                _context.SaveChanges();

                if (deleteOrder)
                {
                    LibrettoHost.WarehouseService.DeleteOrder(transactionIdentifier);
                }

                return EmailClient.Instance.NotifyCancel(sqlEntity);
            }
            catch
            {
                return Response.DatabaseError;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionStatus"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        public Response Update(Guid transactionIdentifier, Status transactionStatus, DateTime transactionTimestamp)
        {
            try
            {
                var sqlEntity = _context.Orders.SingleOrDefault(orderInformation => orderInformation.Id == transactionIdentifier);

                if (sqlEntity == null)
                {
                    return Response.NotFound;
                }

                if (sqlEntity.Status == transactionStatus)
                {
                    return Response.BadRequest;
                }

                if (transactionStatus < sqlEntity.Status || transactionStatus == Status.Cancelled || sqlEntity.Status > Status.Processing)
                {
                    return Response.BadRequest;
                }

                sqlEntity.Status = transactionStatus;
                sqlEntity.StatusTimestamp = transactionTimestamp;
                _context.SaveChanges();

                if (transactionStatus != Status.Waiting)
                {
                    LibrettoHost.WarehouseService.DeleteOrder(transactionIdentifier);
                }

                if (transactionStatus == Status.Processing && LibrettoDatabase.BookIntegration.UpdateStock(sqlEntity.BookId, -10) != Response.Success)
                {
                    return Response.DatabaseError;
                }

                return EmailClient.Instance.NotifyUpdate(sqlEntity);
            }
            catch
            {
                return Response.DatabaseError;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public Response DeleteOrder(Guid transactionIdentifier)
        {
            try
            {
                var sqlEntity = _context.Orders.SingleOrDefault(orderInformation => orderInformation.Id == transactionIdentifier);

                if (sqlEntity == null)
                {
                    return Response.NotFound;
                }

                _context.Orders.Remove(sqlEntity);
                _context.SaveChanges();

                if (sqlEntity.Status == Status.Waiting)
                {
                    LibrettoHost.WarehouseService.DeleteOrder(transactionIdentifier);
                }

                return EmailClient.Instance.NotifyCancel(sqlEntity);
            }
            catch
            {
                return Response.DatabaseError;
            }
        }
    }
}