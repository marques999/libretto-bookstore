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
        /// <param name="orderIdentifier"></param>
        public void DeleteOrder(Guid orderIdentifier)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseOrder"></param>
        public void InsertOrder(WarehouseOrder warehouseOrder)
        {
            try
            {
                WarehouseLogger.LogMessage(Resources.MessagingInsertOrder, warehouseOrder.Identifier, warehouseOrder.Title, warehouseOrder.Timestamp);
                WarehouseServer.InsertOrder(warehouseOrder);
            }
            catch (Exception ex)
            {
                WarehouseLogger.LogException(ex);
            }
        }
    }
}