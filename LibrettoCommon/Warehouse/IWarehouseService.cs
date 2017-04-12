using System;
using System.Collections.Generic;

namespace Libretto.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public delegate void TransactionHandler(List<WarehouseOrder> transactionInformation);

    /// <summary>
    ///
    /// </summary>
    public interface IWarehouseService
    {
        /// <summary>
        /// 
        /// </summary>
        event TransactionHandler OnRefresh;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<WarehouseOrder> ListOrders();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        bool DispatchOrder(Guid transactionIdentifier);
    }
}