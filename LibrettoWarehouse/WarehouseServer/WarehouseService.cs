using System;

using Libretto.Properties;
using Libretto.Warehouse;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseService : IWarehouseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseOrder"></param>
        public void InsertOrder(WarehouseOrder warehouseOrder)
        {
            try
            {
                warehouseOrder.DateCreated = DateTime.Now;
                warehouseOrder.DateModified = warehouseOrder.DateCreated;
                WarehouseLogger.LogMessage(Resources.MessagingInsertOrder, warehouseOrder.Identifier, warehouseOrder.Title, warehouseOrder.DateCreated);
                WarehouseServer.InsertOrder(warehouseOrder);
            }
            catch (Exception ex)
            {
                WarehouseLogger.LogException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <param name="orderQuantity"></param>
        /// <param name="orderTotal"></param>
        public void UpdateOrder(Guid orderIdentifier, int orderQuantity, double orderTotal)
        {
            try
            {
                WarehouseLogger.LogMessage(Resources.MessagingUpdateOrder, orderIdentifier, orderQuantity, orderTotal);
                WarehouseServer.UpdateOrder(orderIdentifier, orderQuantity, orderTotal);
            }
            catch (Exception ex)
            {
                WarehouseLogger.LogException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        public void CancelOrder(Guid orderIdentifier)
        {
            try
            {
                WarehouseLogger.LogMessage(Resources.MessagingCancelOrder, orderIdentifier);
                WarehouseServer.DeleteOrder(orderIdentifier);
            }
            catch (Exception ex)
            {
                WarehouseLogger.LogException(ex);
            }
        }
    }
}