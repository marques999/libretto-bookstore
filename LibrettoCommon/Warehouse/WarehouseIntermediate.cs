using System;

namespace Libretto.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseIntermediate : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        public event WarehouseDeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        public void Delete(Guid transactionIdentifier)
        {
            OnDelete?.Invoke(transactionIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        public event WarehouseUpsertHandler OnUpsert;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseOrder"></param>
        public void Upsert(WarehouseOrder warehouseOrder)
        {
            OnUpsert?.Invoke(warehouseOrder);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}