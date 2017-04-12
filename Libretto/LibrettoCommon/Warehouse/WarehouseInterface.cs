using System;
using System.Collections.Generic;

using Libretto.Model;

namespace Libretto.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    public delegate void RefreshHandler();

    /// <summary>
    ///
    /// </summary>
    public interface WarehouseInterface
    {
        /// <summary>
        /// 
        /// </summary>
        event RefreshHandler OnRefreshBooks;

        /// <summary>
        /// 
        /// </summary>
        event RefreshHandler OnRefreshOrders;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Order> ListOrders();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<Guid, Book> ListBooks();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <param name="bookQuantity"></param>
        /// <returns></returns>
        bool UpdateStock(Guid bookIdentifier, int bookQuantity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionStatus"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        bool UpdateOrder(Guid transactionIdentifier, Status transactionStatus, DateTime transactionTimestamp);
    }
}