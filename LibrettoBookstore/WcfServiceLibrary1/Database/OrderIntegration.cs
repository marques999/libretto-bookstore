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
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Order Lookup(Guid orderIdentifier)
        {
            try
            {
                return _context.Orders.SingleOrDefault(transactionInformation => transactionInformation.Id == orderIdentifier);
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
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public List<Order> List(Guid orderIdentifier)
        {
            try
            {
                return _context.Orders.Where(orderInformation => orderInformation.CustomerId == orderIdentifier).ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public Response Insert(Order orderInformation)
        {
            try
            {
                if (orderInformation == null)
                {
                    return Response.InvalidArguments;
                }

                var bookInformation = LibrettoDatabase.BookIntegration.Lookup(orderInformation.BookId);

                if (bookInformation == null)
                {
                    return Response.NotFound;
                }

                orderInformation.Timestamp = DateTime.Now;

                if (orderInformation.Quantity > bookInformation.Stock)
                {
                    orderInformation.Status = Status.Waiting;
                    orderInformation.StatusTimestamp = orderInformation.Timestamp;
                }
                else
                {
                    orderInformation.Status = Status.Dispatched;
                    orderInformation.StatusTimestamp = DateTime.Now.AddDays(1);
                }

                _context.Orders.Add(orderInformation);
                _context.SaveChanges();

                if (orderInformation.Status == Status.Waiting)
                {
                    LibrettoHost.WarehouseService.InsertOrder(WarehouseOrder.FromOrder(orderInformation));
                }
                else
                {
                    LibrettoDatabase.BookIntegration.UpdateStock(orderInformation.BookId, -orderInformation.Quantity);
                }

                StoreService.NotifyRegisterTransaction(orderInformation);

                return EmailClient.Instance.NotifyInsert(orderInformation);
            }
            catch
            {
                return Response.DatabaseError;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Response Cancel(Guid orderIdentifier)
        {
            try
            {
                var sqlEntity = _context.Orders.SingleOrDefault(previousTransaction => previousTransaction.Id == orderIdentifier);

                if (sqlEntity == null)
                {
                    return Response.NotFound;
                }

                if (sqlEntity.Status > Status.Pending)
                {
                    return Response.BadRequest;
                }

                var statusWaiting = sqlEntity.Status == Status.Waiting;

                sqlEntity.Status = Status.Cancelled;
                sqlEntity.StatusTimestamp = DateTime.Now;
                _context.SaveChanges();

                if (statusWaiting)
                {
                    LibrettoHost.WarehouseService.DeleteOrder(orderIdentifier);
                }
                else if (LibrettoDatabase.BookIntegration.UpdateStock(sqlEntity.BookId, 10 + sqlEntity.Quantity) != Response.Success)
                {
                    return Response.DatabaseError;
                }

                StoreService.NotifyUpdateTransaction(sqlEntity);

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
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Response Satisfy(Guid orderIdentifier)
        {
            try
            {
                var sqlEntity = _context.Orders.SingleOrDefault(orderInformation => orderInformation.Id == orderIdentifier);

                if (sqlEntity == null)
                {
                    return Response.NotFound;
                }

                if (sqlEntity.Status != Status.Waiting)
                {
                    return Response.BadRequest;
                }

                sqlEntity.Status = Status.Pending;
                sqlEntity.StatusTimestamp = DateTime.Now.AddDays(2);
                _context.SaveChanges();
                StoreService.NotifyUpdateTransaction(sqlEntity);

                return EmailClient.Instance.NotifyPending(sqlEntity);
            }
            catch
            {
                return Response.DatabaseError;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Response Dispatch(Guid orderIdentifier)
        {
            try
            {
                var sqlEntity = _context.Orders.SingleOrDefault(orderInformation => orderInformation.Id == orderIdentifier);

                if (sqlEntity == null)
                {
                    return Response.NotFound;
                }

                if (sqlEntity.Status != Status.Pending)
                {
                    return Response.BadRequest;
                }

                sqlEntity.Status = Status.Dispatched;
                sqlEntity.StatusTimestamp = DateTime.Now;
                _context.SaveChanges();

                if (LibrettoDatabase.BookIntegration.UpdateStock(sqlEntity.BookId, 10) != Response.Success)
                {
                    return Response.DatabaseError;
                }

                StoreService.NotifyUpdateTransaction(sqlEntity);

                return EmailClient.Instance.NotifyDispatch(sqlEntity);
            }
            catch
            {
                return Response.DatabaseError;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Response Delete(Guid orderIdentifier)
        {
            try
            {
                var sqlEntity = _context.Orders.SingleOrDefault(orderInformation => orderInformation.Id == orderIdentifier);

                if (sqlEntity == null)
                {
                    return Response.NotFound;
                }

                _context.Orders.Remove(sqlEntity);
                _context.SaveChanges();

                if (sqlEntity.Status == Status.Waiting)
                {
                    LibrettoHost.WarehouseService.DeleteOrder(orderIdentifier);
                }

                StoreService.NotifyDeleteTransaction(orderIdentifier);

                if (sqlEntity.Status < Status.Dispatched)
                {
                    return EmailClient.Instance.NotifyCancel(sqlEntity);
                }
            }
            catch
            {
                return Response.DatabaseError;
            }

            return Response.Success;
        }
    }
}