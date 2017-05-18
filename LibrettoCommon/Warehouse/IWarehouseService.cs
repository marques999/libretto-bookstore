using System;
using System.Collections.Generic;

namespace Libretto.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="warehouseOrder"></param>
    public delegate void WarehouseUpsertHandler(WarehouseOrder warehouseOrder);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="transactionIdentifier"></param>
    public delegate void WarehouseDeleteHandler(Guid transactionIdentifier);

    /// <summary>
    /// 
    /// </summary>
    public interface IWarehouseService
    {
        /// <summary>
        /// 
        /// </summary>
        event WarehouseDeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        event WarehouseUpsertHandler OnUpsert;

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